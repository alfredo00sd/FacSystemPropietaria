//Js OOP app
//alert("Hey");

class Product {
    constructor(name, quantity) {
        this.name = name;
        this.quantity = quantity;
    }
}

//interact with the html
class UI {

    addProducts(product) {
        const productList = document.getElementById('products-list');
        const element = document.createElement('div');

        element.innerHTML = `
        <div class="card text-center mb-4">
            <div class="card-body">
                <strong>Producto</strong>: ${product.name}
                <strong>Cantidad</strong>: ${product.quantity}
                <a name="delete" href="#" class="btn btn-danger">Remover</a>
            </div>
        </div> 
        `;

        productList.appendChild(element);
        this.clearForm();
    }

    clearForm() {
        document.getElementById('product-form').reset();
    }

    deleteProducts(element) {
        if (element.name == 'delete') {
            console.log(element.parentElement.parentElement.remove());
        }
    }
}

//DOM EVENTS
//Submit form event
document.getElementById('addItem').addEventListener('click', function (e) {
    //Get text name for producto no id
    const name = document.getElementById('ItemName').options[document.getElementById('ItemName').selectedIndex].text;
    const quantity = document.getElementById('quantity').value;

    //Get value for Id
    const ItemId = document.getElementById('ItemName').value;
    const ItemQ = document.getElementById('quantity').value;
    //console.log(name, price, year);
    document.getElementById("ItemsId").value = document.getElementById("ItemsId").value +","+ItemId;
    document.getElementById("ItemsQ").value  = document.getElementById("ItemsQ").value + "," + ItemQ;

    const product = new Product(name, quantity);
    const ui = new UI();

    ui.addProducts(product);
    //ui.clearForm();

    //prevent the default reloadin of the form
    e.preventDefault();
});

//event delete 
document.getElementById('products-list').addEventListener('click', function (e) {
    //console.log(e.target);
    const ui = new UI();

    ui.deleteProducts(e.target);
});


