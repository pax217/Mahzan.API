/*
 * Proyecto: 	Mahzan.Api
 * Sección:		AspNetUsers
 * Autor: 		Carlos Alberto Maldonado Díaz.
 *  
 */ 
 ---------------------------------------------------------
/*	Obtiene Usuarios de la aplicación*/
--------------------------------------------------------- 
Select * from AspNetUsers
where UserName like '%mahzan%'

Select * from Members
Where AspNetUsersId in('10343743-b940-412e-b92e-400a0ba2ad07')