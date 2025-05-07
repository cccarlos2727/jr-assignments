// Q1-var, let and const
// Given
// var name = "Alice";
// if(true){
//     var name = "Bob";
//     console.log(name);
// }

// console.log(name);

// Using let
// let name = "Alice";
// if(true){
//     let name = "Bob";
//     console.log("Within scope", name);
// }

// console.log("Outsie scope", name);

// Using const
const name = "Alice";
if(true){
    const name = "Bob";
    console.log("Within scope", name);
}

console.log("Outsie scope", name);

// Explaination: Because "var" ignores the block-scope (like insdie if, for), so the value of "name" in inner scope over-writes the outer one, may result in error. The "let" and "const" recognize the block-scope and are not behaved like "var".


// Q2-arrow function

// function add(a, b) {
//     return a + b;
// }

const add = (a, b) => a + b;

console.log(add(3,5));
// When using the typical function approach, "this" refers to object who the function, but when we are using arrow function, it itself does not have a "this", it has to refer to the surrounding scope for "this" when the arrow function is created. If there isnt, it is usually "undefined".


// Q3-Template Literals
// let greeting = "Hello, " + name + "! Welcome to the course.";
let greeting = `Hello ${name}! Welcome to the course\n`;
console.log(greeting);

// Q4-Destructuring
const person = {
    name: "Ben",
    age: 25,
    city: "Sydney"
};

function greetingAgain({name, age}) {
    console.log(`Name is ${name}, age is ${age}`);
}
greetingAgain(person);

// Q5-Default Parameter
function calculateArea(width=30, height=30) {
    return width * height;
}
let res = calculateArea();
console.log(`The area is ${res}`);


// Q6-Rest/Spread
function sum(...arr) {
    return arr.reduce((total, current) => total + current, 0);
}
// const sum = (...arr) => arr.reduce((total, current) => total + current, 0);
console.log(sum(3,10));

let arr1 = [1,2];
let arr2 = [3,4];
let merged = [...arr1, ...arr2];
console.log(merged);