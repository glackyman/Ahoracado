# 🎮 Juego del Ahorcado (Cliente/Servidor)

## 📌 Descripción

Este proyecto es una implementación del clásico **Juego del Ahorcado** desarrollado en **C#** utilizando una arquitectura **cliente-servidor** sobre **.NET Framework 4.7.2**.

El cliente es una aplicación de escritorio (WinForms) que se conecta mediante TCP a un servidor para obtener palabras, registrar partidas y consultar récords.

## 🧱 Estructura de la Solución

-   **🖥️ Juego**: Aplicación WinForms donde el usuario juega al ahorcado.
-   **🖧 Ejercicio5 (Servidor)**: Aplicación de consola que gestiona palabras y récords vía sockets TCP.
-   **📦 ComponenteJuego** _(opcional)_: Biblioteca de componentes reutilizables para el juego.

## ⚙️ Funcionamiento

1.  **El servidor** debe iniciarse antes que el cliente:
    
    -   Escucha conexiones TCP en el puerto `31416`.
    -   Gestiona archivos de palabras y récords.
    -   Atiende peticiones de los clientes para obtener y guardar datos.
2.  **El cliente** se conecta al servidor para:
    
    -   Solicitar una palabra aleatoria.
    -   Enviar un nuevo récord al terminar una partida.
    -   Consultar la lista de récords.
3.  **Dinámica del juego**:
    
    -   El usuario adivina la palabra letra por letra.
    -   Tiene **7 vidas**.
    -   El tiempo de partida se registra.
    -   Al ganar, puede guardar su récord; al perder, puede reiniciar.

## 🖼️ Capturas de Pantalla _(opcional)_

## 🧪 Instalación y Ejecución

### Requisitos

-   Windows con .NET Framework 4.7.2
-   Visual Studio 2022 (recomendado para el desarrollo)

### Pasos

1.  Clona o descarga el repositorio que contiene el Servidor (`Ejercicio5`) y el Cliente (`Juego`).
2.  Abre la solución (`.sln`) en Visual Studio.
3.  **Ejecuta el servidor**: Inicia el proyecto `Ejercicio5` (por ejemplo, haciendo clic derecho en el proyecto y seleccionando "Depurar" -> "Iniciar nueva instancia" o configurándolo como proyecto de inicio múltiple).
4.  **Ejecuta el cliente**: Inicia el proyecto `Juego` de la misma manera.
5.  **Configuración de red**: Si el servidor se ejecuta en otra máquina, puedes modificar la IP y el puerto en la configuración del cliente (a través de la interfaz del juego) para establecer la conexión correcta.

## 🛰️ Comandos del Servidor

El cliente se comunica con el servidor por sockets TCP mediante los siguientes comandos de protocolo:

Comando

Descripción

`getword`

Devuelve una palabra aleatoria del servidor.

`sendword <palabra>`

Añade una nueva palabra a la lista del servidor.

`getrecords`

Devuelve la lista de récords almacenados.

`sendrecord <nombre,tiempo>`

Añade un nuevo récord (nombre y tiempo) al servidor.

Exportar a Hojas de cálculo

## 🧩 Personalización

-   Puedes añadir palabras al servidor utilizando el comando `sendword` desde el cliente, o editando manualmente el archivo `words.txt` en la ubicación del servidor (por defecto, `C:\ProgramData\AhorcadoGame\`).
-   Los récords se almacenan en el servidor (`records.bin`) y pueden consultarse desde el cliente (funcionalidad en desarrollo).

## ✅ TODO

-   Implementar la funcionalidad completa para **enviar nuevas palabras** desde el cliente (`sendword`).
-   Asegurar el correcto **envío de récords** desde el cliente al servidor (`sendrecord`).
-   Desarrollar la funcionalidad para **obtener y mostrar récords** desde el cliente (`getrecords`), incluyendo una interfaz de usuario adecuada.
-   Mejorar el **manejo de errores** cuando el servidor no esté disponible o la conexión falle, proporcionando feedback claro al usuario y evitando la congelación de la UI. Esto puede implicar el uso de operaciones asíncronas para la comunicación de red.

## 📝 Notas

-   El cliente mostrará un mensaje de error si no puede conectarse al servidor en la IP y puerto especificados.
-   La IP y el puerto de conexión del cliente son configurables y se guardan para futuras sesiones.

## 🧠 Tecnologías Utilizadas

-   **C#**
-   **Windows Forms (WinForms)**
-   **.NET Framework 4.7.2**
-   **Sockets TCP**

## 👨‍💻 Créditos

Desarrollado como ejercicio educativo de programación en C# y .NET Framework.
