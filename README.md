# Juego del Ahorcado (Cliente/Servidor)

## Descripción

Este proyecto es una implementación del clásico **juego del ahorcado** en C# utilizando una arquitectura cliente-servidor sobre .NET Framework 4.7.2.  
El cliente es una aplicación de escritorio (WinForms) que se conecta a un servidor TCP para obtener palabras y gestionar los récords de los jugadores.

---

## Estructura de la solución

- **Juego**: Cliente WinForms donde el usuario juega al ahorcado.
- **Ejercicio5 (TheServer)**: Servidor de consola que gestiona palabras y récords.
- **ComponenteJuego**: (Opcional) Componentes reutilizables para el juego.

---

## Funcionamiento

1. **El servidor** debe ejecutarse antes que el cliente.
   - Escucha conexiones TCP en el puerto 31416.
   - Gestiona archivos de palabras y récords.
   - Atiende peticiones de los clientes para obtener palabras, añadir palabras y guardar/consultar récords.

2. **El cliente** se conecta al servidor para:
   - Solicitar una palabra aleatoria.
   - Enviar un nuevo récord al finalizar la partida.
   - Consultar la lista de récords.

3. **Dinámica del juego**:
   - El usuario adivina la palabra letra a letra.
   - Dispone de 7 vidas.
   - El tiempo de partida se registra.
   - Al ganar, puede guardar su récord.
   - Al perder, puede iniciar una nueva partida.

---

## Instalación y ejecución

### Requisitos

- Windows con .NET Framework 4.7.2
- Visual Studio 2022 (recomendado)

### Pasos

1. Descargar el Servidor y el Juego
2. Abrir el servidor
3. Abrir el juego
4. Puedes jugar con cliente si dejas el server abierto en otro equipo

---

## Comandos del servidor

El cliente se comunica con el servidor usando los siguientes comandos por socket:

- `getword` — Devuelve una palabra aleatoria.
- `sendword <palabra>` — Añade una nueva palabra.
- `getrecords` — Devuelve la lista de récords.
- `sendrecord <nombre,tiempo>` — Añade un nuevo récord.

---

## Personalización

- Puedes añadir palabras al servidor usando el comando `sendword` o editando el archivo de palabras.
- Los récords se almacenan en el servidor y pueden consultarse desde el cliente.

---

## Notas

- Si el servidor no está disponible, el cliente mostrará un mensaje de error.
- Puedes modificar la IP y el puerto en el código del cliente si el servidor se ejecuta en otra máquina o puerto.

---

## Créditos

Desarrollado como ejercicio de programación en C# y .NET Framework.
