/*
 * Proyecto: 	Mahzan.Api
 * Secci�n:		AspNetUsers
 * Autor: 		Carlos Alberto Maldonado D�az.
 *  
 */ 
 ---------------------------------------------------------
/*	Obtiene Usuarios de la aplicaci�n*/
--------------------------------------------------------- 
Select * from AspNetUsers
where UserName like '%mahzan%'

Select * from Members
Where AspNetUsersId in('10343743-b940-412e-b92e-400a0ba2ad07')