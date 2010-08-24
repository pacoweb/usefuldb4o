T4_OledbToOO_Templates
---------------------------------
Este directorio contiene las plantillas necesarias para generar 
un modelo de entidades (clases) orientado a objetos a partir de
una base de datos relacional.

Aunque se puede usar separadamente, est� especialmente dise�adas para trabajar con la librer�a UsefulDB4O para migrar
datos de bases de datos relacionales a bases de datos de objetos en formato Db4o (http://developer.db4o.com/).


--> Requisitos para su uso

1) Visual Studio 2008
2) T4 Toolbox (Descargar en http://t4toolbox.codeplex.com/)

--> Plantillas

ClassTemplate.tt: plantilla que sirve de modelo para todas las clases que se van a generar. Esta plantilla no se debe editar.
DatabaseToModelGenerator.tt: plantilla que contiene el generador de plantillas. Esta plantilla no se debe editar.

ModelFromDatabase.tt: es donde se realiza la configuraci�n de la generaci�n de c�digo. Es la �nica plantilla que hay que modificar.

--> Comenzar a usar:

1) Crea un proyecto de tipo Biblioteca de clases (Es mejor tener separadas las entidades)
2) A�ade las plantillas a tu proyecto
3) Abre el archivo ModelFromDatabase.tt y edita la configuraci�n:

	3.1) El valor m�s importante es la propiedad DataBaseConnectionString que indica la cadena de conexi�n 
	que se va a usar para conectar con la base de datos relacional. 