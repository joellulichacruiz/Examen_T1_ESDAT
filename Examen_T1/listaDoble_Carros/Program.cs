using listaDoble_Carros;
using System;

Console.WriteLine("Examen T1: Demostración de Lista Enlazada Doble de Carros\n");

/* Creao la lista y la completo usando el método AgregaDosCarros */
var listaCar = new ListaEnlazadaS();

/* Uso 4 llamadas (8 carros) y luego se quita uno para obtener 7 elementos.
De este modo la creación principal emplea AgregaDosCarros.*/
listaCar.AgregaDosCarros("Toyota", 4, 1800, "Ford", 2, 1600);
listaCar.AgregaDosCarros("Honda", 4, 1500, "Chevrolet", 2, 1400);
listaCar.AgregaDosCarros("BMW", 2, 2000, "Audi", 4, 1800);
listaCar.AgregaDosCarros("Kia", 4, 1300, "Hyundai", 2, 1200);

/* Quitar el penúltimo para quedarme con 7 elementos*/
listaCar.QuitaPenultimoCarro();

Console.WriteLine("Contenido inicial de la lista de Carros:");
Console.WriteLine(listaCar.ToString());
Console.WriteLine("---------------------------------------------");

/* ListaSegunPuerta */
var filtrada = listaCar.ListaSegunPuerta(2, 4);
Console.WriteLine("Lista filtrada por número de puertas de 2 a 4:");
Console.WriteLine(filtrada.ToString());
Console.WriteLine("---------------------------------------------");

/* QuitaPenultimoCarro sobre la lista original y muestra el resultado*/
listaCar.QuitaPenultimoCarro();
Console.WriteLine("Nueva lista de Carros después de quitar el penúltimo");
Console.WriteLine(listaCar.ToString());
Console.WriteLine("---------------------------------------------");

/* Preparar la segunda lista para MezclaParImpar */
var segunda = new ListaEnlazadaS();
segunda.AgregaDosCarros("Seat", 4, 1600, "Mazda", 2, 1400);
segunda.AgregaDosCarros("Renault", 4, 1300, "Subaru", 4, 2000);
segunda.AgregaDosCarros("Fiat", 2, 1000, "Mercedes", 4, 2200);

Console.WriteLine("Segunda lista (Para mezclar):");
Console.WriteLine(segunda.ToString());
Console.WriteLine("--------------------------------------------- :)");

/* Mezclar impares de listaCar con pares de segunda lista*/
var mezclada = listaCar.MezclaParImpar(segunda);
Console.WriteLine("Resultado de Mezclar impares de la primera lista con pares de la segunda:");
Console.WriteLine(mezclada.ToString());
Console.WriteLine("\nPresione una tecla para salir del programa");
Console.ReadKey();
