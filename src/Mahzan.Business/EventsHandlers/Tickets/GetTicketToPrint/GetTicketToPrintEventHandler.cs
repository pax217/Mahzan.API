﻿using Mahzan.Business.Events.Tickets.GetTicketToPrint;
using Mahzan.Business.Utils;
using Mahzan.Dapper.DTO.Tickets.GetTicketToPrint;
using Mahzan.Dapper.Repositories.Companies.GetCompany;
using Mahzan.Dapper.Repositories.Company_Adress.GetCompanyAdress;
using Mahzan.Dapper.Repositories.Company_Contact.GetCompanyContact;
using Mahzan.Dapper.Repositories.TicketDetail.GetTicketDetail;
using Mahzan.Dapper.Repositories.Tickets.GetTicket;
using Mahzan.Dapper.Repositories.Tickets.GetTicketToPrint;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Tickets.GetTicketToPrint
{
    public class GetTicketToPrintEventHandler : IGetTicketToPrintEventHandler
    {
        private const int LENGTH_ROW = 32;

        private readonly IGetTicketToPrintRepository _getTicketToPrintRepository;

        private readonly IGetCompanyRepository _getCompanyRepository;

        private readonly IGetCompanyAdressRepository _getCompanyAdressRepository;

        private readonly IGetCompanyContactRepository _getCompanyContactRepository;

        private readonly IGetTicketDetailRepository _getTicketDetailRepository;

        private readonly IGetTicketRepository _getTicketRepository;

        public GetTicketToPrintEventHandler(
            IGetTicketToPrintRepository getTicketToPrintRepository,
            IGetCompanyRepository getCompanyRepository, 
            IGetCompanyAdressRepository getCompanyAdressRepository,
            IGetCompanyContactRepository getCompanyContactRepository,
            IGetTicketDetailRepository getTicketDetailRepository,
            IGetTicketRepository getTicketRepository)
        {
            _getTicketToPrintRepository = getTicketToPrintRepository;
            _getCompanyRepository = getCompanyRepository;
            _getCompanyAdressRepository = getCompanyAdressRepository;
            _getCompanyContactRepository = getCompanyContactRepository;
            _getTicketDetailRepository = getTicketDetailRepository;
            _getTicketRepository = getTicketRepository;
        }

        public async Task<string> Handle(GetTicketToPrintEvent getTicketToPrintEvent)
        {
            string ticket = string.Empty;

            //Validators

            //Build Ticket
            ticket = await BuildTicket(getTicketToPrintEvent);


            return ticket;
        }

        private async Task<string> BuildTicket(GetTicketToPrintEvent getTicketToPrintEvent) 
        {
            string ticket = string.Empty;

            //Repository
            Models.Entities.Tickets tickets = await _getTicketToPrintRepository
                                                .Handle(new GetTicketToPrintDto
                                                {
                                                    TicketsId = getTicketToPrintEvent.TicketsId,
                                                    MembersId = getTicketToPrintEvent.MembersId
                                                });

            ticket = await BluidTicketFromEntities(tickets);

            return ticket;
        }

        private async Task<string> BluidTicketFromEntities(
            Models.Entities.Tickets ticket
            ) 
        {
            StringBuilder ticketFromEntities = new StringBuilder();

            ticketFromEntities.Append("-------------------------------\n");
            ticketFromEntities.Append(FormatRow(await GetCompanyCommercialName(ticket.PointsOfSalesId)));
            ticketFromEntities.Append("-------------------------------\n");
            ticketFromEntities.Append(await GetCompanyAdress(ticket.PointsOfSalesId));
            ticketFromEntities.Append("-------------------------------\n");
            ticketFromEntities.Append(await GetCompanyContact(ticket.PointsOfSalesId));
            ticketFromEntities.Append("-------------------------------\n"); //Separador
            ticketFromEntities.Append("Descripcion        C.     Monto\n"); //Cabecero Detalle de Ticket
            ticketFromEntities.Append("-------------------------------\n"); //Separador
            ticketFromEntities.Append(await GetTicketDetail(ticket.TicketsId));
            ticketFromEntities.Append("-------------------------------\n");
            ticketFromEntities.Append(await GetTicketTotal(ticket.TicketsId));
            ticketFromEntities.Append("-------------------------------\n");
            ticketFromEntities.Append("     ***COPIA DE CLIENTE***    \n");
            ticketFromEntities.Append("-------------------------------\n");
            ticketFromEntities.Append(" *** Gracias por su compra *** \n");
            ticketFromEntities.Append("-------------------------------\n");

            return ticketFromEntities.ToString();

        }

        private async Task<string> GetCompanyCommercialName(Guid pointsOfSaleId) 
        {
            StringBuilder commercialName = new StringBuilder();

            Models.Entities.Companies comapny = await _getCompanyRepository
                .GetByPointsOfSalesId(pointsOfSaleId);

            if (comapny == null)
            {
                commercialName.Append("<Sin nombre commercial>");
            }
            else 
            {
                commercialName.Append(comapny.CommercialName);
            }

            return commercialName.ToString();
        }

        private async Task<string> GetCompanyAdress(Guid pointsOfSaleId) 
        {
            StringBuilder companyAdressString = new StringBuilder();

            Models.Entities.Company_Adress companyAdress = await _getCompanyAdressRepository
                .GetByPointsOfSalesId(pointsOfSaleId);

            companyAdressString.Append(companyAdress.Street + " N." + companyAdress.OutdoorNumber + "\n");
            companyAdressString.Append(companyAdress.Suburb + "\n");
            companyAdressString.Append(companyAdress.TownHall + "\n");
            companyAdressString.Append(companyAdress.State + "\n");
            companyAdressString.Append(companyAdress.City + "\n");
            companyAdressString.Append(companyAdress.PostalCode + "\n");

            return companyAdressString.ToString();
        }

        private async Task<string> GetCompanyContact(Guid pointsOfSaleId) 
        {
            StringBuilder companyContactString = new StringBuilder();

            Models.Entities.Company_Contact companyContact = await _getCompanyContactRepository
                .GetByPointsOfSalesId(pointsOfSaleId);

            if (companyContact != null)
            {
                companyContactString.Append(companyContact.Phone + "\n");
                companyContactString.Append(companyContact.WebSite + "\n");
            }
            else 
            {
                companyContactString.Append("<falta telefono>" + "\n");
                companyContactString.Append("<falta website>" + "\n");
            }


            return companyContactString.ToString();
        }

        private async Task<string> GetTicketDetail(Guid ticketsId) 
        {
            StringBuilder ticketDetailString = new StringBuilder();


            List<Models.Entities.TicketDetail> ticketDetails = await _getTicketDetailRepository
                .GetByTicketsId(ticketsId);

            foreach (var ticketDetail in ticketDetails)
            {
                ticketDetailString.Append(ticketDetail.Description + "\n");
                ticketDetailString.Append(FormatQuantityAmountRow(ticketDetail.Quantity.ToString(),
                                                     ticketDetail.Amount.ToString()));
                ticketDetailString.Append("-------------------------------\n");
            }

            return ticketDetailString.ToString();
        }

        private async Task<string> GetTicketTotal(Guid ticketsId) 
        {
            StringBuilder ticketTotal = new StringBuilder();

            Models.Entities.Tickets ticket = await _getTicketRepository
                .GetByTicketsId(ticketsId);

            ticketTotal.Append(FormatTotalProducts(ticket.TotalProducts.ToString()));
            ticketTotal.Append("-------------------------------\n");
            ticketTotal.Append(FormatDescriptionMoneyRow("Total", ticket.Total.ToString()));
            ticketTotal.Append("-------------------------------\n");
            ticketTotal.Append(FormatDescriptionMoneyRow("Pago", ticket.CashPayment.ToString()));
            ticketTotal.Append(FormatDescriptionMoneyRow("Cambio", ticket.CashExchange.ToString()));
            ticketTotal.Append("-------------------------------\n");
            string totalLetter = CurrencyToLetter.Convertir(ticket.Total.ToString(),
                                                            true);
            ticketTotal.Append(totalLetter + "\n");
            ticketTotal.Append("-------------------------------\n");


            return ticketTotal.ToString();
        }


        #region Utils Ticket Format
        private string FormatRow(string valueRow)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int length = valueRow.Length;
            int lenghtEmpty = LENGTH_ROW - length;
            decimal lengthLeftAndRigth = ((lenghtEmpty / 2) - 4);
            //decimal lengthLeftAndRigth = Math.Round(lengthMiddle, 
            //                                  MidpointRounding.AwayFromZero);

            stringBuilder.Append(' ', (int)lengthLeftAndRigth);
            stringBuilder.Append("- " + valueRow + " -");
            stringBuilder.Append(' ', (int)lengthLeftAndRigth);
            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }

        private string FormatQuantityAmountRow(string quantity,
                                      string amount)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int LENGTH_QUANTITY = 20;
            int WHITE_SAPCE_QUANTITY = LENGTH_QUANTITY - quantity.Length;

            stringBuilder.Append(' ', (int)WHITE_SAPCE_QUANTITY);
            stringBuilder.Append(quantity);

            int LENGTH_PRICE = 11;
            int WHITE_SAPCE_PRICE = LENGTH_PRICE - amount.Length;

            stringBuilder.Append(' ', (int)WHITE_SAPCE_PRICE);
            stringBuilder.Append(amount);

            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }

        private string FormatTotalProducts(string totalProducts)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("# ARTICULOS VENDIDOS");

            int LENGTH_TOTAL_PRODUCTS = 11;
            int WHITE_SAPCE_TOTAL_PRODUCTS = LENGTH_TOTAL_PRODUCTS - totalProducts.Length;

            stringBuilder.Append(' ', (int)WHITE_SAPCE_TOTAL_PRODUCTS);
            stringBuilder.Append(totalProducts);
            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }

        private string FormatDescriptionMoneyRow(string description, string money)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int LENGTH_DESCRIPTION = 20;
            int WHITE_SAPCE_DESCRIPTION = LENGTH_DESCRIPTION - description.Length;

            stringBuilder.Append(' ', (int)WHITE_SAPCE_DESCRIPTION);
            stringBuilder.Append(description);

            int LENGTH_TOTAL = 11;
            int WHITE_SAPCE_MONEY = LENGTH_TOTAL - money.Length;

            stringBuilder.Append(' ', (int)WHITE_SAPCE_MONEY);
            stringBuilder.Append(money);
            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }

        #endregion
    }
}
