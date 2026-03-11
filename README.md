# Ubimia-PruebaTecnica
Este repositorio contiene la solución de la prueba técnica dividida en dos partes:

- Aplicación ASP.NET
- Script SQL para procesamiento de datos

El objetivo es implementar una aplicación web con dos funcionalidades principales y generar dos tablas en sql y crear una tercer tabla de resumen con cálculos agregados.

---

# ASP.NET

La aplicación permite:

- Calcular el factorial de un número
- Ordenar una lista de números

Se implementó un único controller, que simplifica toda la estructura, llamado CalculosController para agrupar las operaciones solicitadas en la prueba.

La lógica del cálculo factorial y del ordenamiento se implementó en métodos privados para mantener el controller más limpio y facilitar la reutilización del código.

Se agregaron las correspondientes validaciones para asegurar que el usuario use nùmeros que posibiliten las operaciones.

También se le agregó CSS para mejorar la visualización de la interfaz.

---

## Cómo ejecutar la aplicación

1. Abrir la solución `.sln` en Visual Studio
2. Ejecutar el proyecto (F5)
3. Usar la interfaz web para probar las funcionalidades

Ejemplo de testeo:

Input:
5

Resultado esperado:
120

---

# SQL

## Objetivo

El script crea las tablas necesarias y genera una tabla de resumen anual de transacciones por cliente.

---

## Creación de base de datos

Les comento que yo cree manualmente la base de datos y luego cree las tablas con sus columnas basandome en el excel.

Una Primary Key se utilizó en la tabla Clientes para asegurar que cada registro tenga un identificador único.

---

## Importación de datos

Los datos fueron importados desde Excel utilizando el Import Wizard de SQL Server.

---

## Limpieza de datos

Se eliminaron registros de transacciones con valores nulos en cliente, ya que esos datos impedirían el correcto calculo en la tabla Resumen que utiliza Join entre transacciones y Clientes, si no tiene clinete es un dato sin pertenencia, por eso se eliminan.

---

## Resultado esperado

El script genera la tabla Resumen que muestra:

- Cliente
- Ingresos
- Año de transacción
- Número de transacciones por año
- Valor total anual de transacciones

Para probarlo se puede ejecutar el comentario al final del script:
SELECT * FROM Resumen; 

---

# Estructura del repositorio

aspnet/
proyecto ASP.NET

sql/
script SQL y 
archivo Excel

README.md

