using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro; // si usas TextMeshPro

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;

    private List<Item> inventario=new List<Item>();

    private void Start()
    {
        // Crear inventario de ejemplo
        inventario.Add(new Item("Espada", "Arma", 150));
        inventario.Add(new Item("Poción de Vida", "Poción", 50));
        inventario.Add(new Item("Arco", "Arma", 120));
        inventario.Add(new Item("Escudo", "Armadura", 100));
        inventario.Add(new Item("Poción de Maná", "Poción", 55));
        inventario.Add(new Item("Espada larga", "Arma", 200));
        inventario.Add(new Item("Cota de malla", "Armadura", 100));
        inventario.Add(new Item("Poción de inmortalidad temporal", "Poción", 85));
        inventario.Add(new Item("Daga", "Arma", 75));
        inventario.Add(new Item("Casco", "Armadura", 100));
        inventario.Add(new Item("Piedra", "Arma", 50));
        inventario.Add(new Item("Poción Venenosa", "Poción", 80));

        MostrarInventario(inventario);
    }

    // Mostrar inventario en el UI
    private void MostrarInventario(IEnumerable<Item> items)
    {
        displayText.text = "";
        foreach (var item in items)
        {
            displayText.text += $"{item.ToString()}\n";
        }
    }

    // Botones
    public void FiltrarPociones()
    {
        var pociones = inventario.Where(i => i.Type == "Poción");
         MostrarInventario(pociones);
    }

    public void OrdenarPorValor()
    {
        var sorted = inventario.OrderByDescending(i => i.Value);
        MostrarInventario(sorted);
    }

    public void AgruparPorTipo()
    {
        var grupos = inventario.GroupBy(i => i.Type);
        displayText.text = "";
        foreach (var grupo in grupos)
        {
            displayText.text += $"--- {grupo.Key} ---\n";
            foreach (var item in grupo)
            {
                displayText.text += $"{item}\n";
            }
        }
    }
}


