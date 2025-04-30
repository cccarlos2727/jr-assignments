// Create an initial shopping list with basic items
let shoppingList = ["milk", "eggs", "bread"];

// Q1: Add two more items to the list using the spread operator
let newShoppingList = [...shoppingList, "juice", "yogurt"];
console.log("After adding items:", newShoppingList);

// Remove the last item ("yogurt") from the list
newShoppingList.pop();
console.log("After removing last item:", newShoppingList);

// Q2: Function to check if the shopping cart is full and display items
function shoppingCarCheck(shoppingCar) {
    // Check if the cart has 5 or more items
    if (shoppingCar.length >= 5) {
        console.log("Your shopping is full");
    }

    // Display up to the first 5 items in the cart
    for (let i = 0; i < 5; i++) {
        if (shoppingCar[i]) {
            console.log(`${i + 1}. ${shoppingCar[i]}`);
        }
    }
}

// Run the cart check on the updated list
shoppingCarCheck(newShoppingList);

// Q3: Function to search for an item in a string array (basic list)
function searchItem(item, shoppingMenu) {
    return shoppingMenu.includes(item);
}

// Use the search function to check if "juice" is in the list
let result = searchItem("juice", newShoppingList);
console.log("Is 'juice' in the list?", result); // true or false

// Q4: Create a more advanced shopping list using objects
let shoppingListObj = [
    {
        name: "milk",      
        price: 12,
        quantity: 1
    },
    {
        name: "eggs",
        price: 22,
        quantity: 3
    },
    {
        name: "bread",
        price: 2,
        quantity: 100
    },
    {
        name: "juice",
        price: 4,
        quantity: 1
    },
];