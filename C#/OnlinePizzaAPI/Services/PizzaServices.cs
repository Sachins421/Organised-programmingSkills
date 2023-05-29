using Microsoft.AspNetCore.Mvc;
using OnlinePizzaAPI.Models;

namespace OnlinePizzaAPI.Services
{
    public class PizzaServices
    {
        static List<Pizza> pizzas;
        static int nextId = 4;

        static PizzaServices() 
        {
            pizzas = new List<Pizza>
            {
                new Pizza { Id = 1 , Name = "Classic Italian", IsGlutenFree = true},
                new Pizza { Id = 2 , Name = "Classic Veggie", IsGlutenFree = true},
                new Pizza { Id = 3 , Name = "Mozorilla", IsGlutenFree = true}
            };
        }

        public static List<Pizza> Getall() => pizzas;

        public static Pizza? Get(int id) => pizzas.FirstOrDefault(p => p.Id == id); 

        public static void add(Pizza pizza) 
        {
            pizza.Id = nextId++;
            pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            pizzas[index] = pizza;
        }
    }
}
