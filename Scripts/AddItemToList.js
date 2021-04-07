class Product {
    constructor(id, name, quantity) {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
    }
}

class UI {

    addProducts(product) {
        const productList = document.getElementById('products-list');
        const element = document.createElement('div');
        const total = document.getElementById('billTotal');
        const subtotal = document.getElementById('subTotal');
        
        element.innerHTML = `
        <div class="card text-center mb-4">
            <div class="card-body">
                <strong>Identificador</strong>: ${product.id} <br/>
                <strong>Producto</strong>: ${product.name} <br/>
                <strong>Cantidad</strong>: ${product.quantity} <br/>
                <a name="delete" href="#" class="btn btn-danger">Remover</a>
            </div>
        </div> 
        `;
        var tot = product.name.split("RD$");
        if (subtotal.value != "") {
            subtotal.value = parseFloat(subtotal.value) + parseFloat(tot[1]);
        } else {
            subtotal.value = tot[1];
        }

        if (total.value != "") {
            total.value = Math.round((parseFloat(total.value) * 0.18) + parseFloat(total.value) + parseFloat(tot[1]), 2);
        } else {
            total.value = Math.round((parseFloat(tot[1]) * 0.18) + parseFloat(tot[1]), 2);
        }
        productList.appendChild(element);
        this.clearForm();
    }

    clearForm() {
        document.getElementById('ItemName').value = "";
        document.getElementById('quantity').value = "";
        //document.getElementById('product-form').reset();
    }

    deleteProducts(element) {
        if (element.name == 'delete') {
            console.log(element.parentElement.parentElement.remove());
        }
    }
}

//Submit form event

document.getElementById('addItem').addEventListener('click', function (e) {

        
    const id = document.getElementById('ItemName').value;
    const name = document.getElementById('ItemName').options[document.getElementById('ItemName').selectedIndex].text;
    const quantity = document.getElementById('quantity').value;

    //Get value for Id
    const ItemId = document.getElementById('ItemName').value;
    const ItemQ = document.getElementById('quantity').value;

    document.getElementById("ItemsId").value = document.getElementById("ItemsId").value + "," + ItemId;
    document.getElementById("ItemsQ").value = document.getElementById("ItemsQ").value + "," + ItemQ;

    const product = new Product(id, name, quantity);
    
    const ui = new UI();
    ui.addProducts(product);

    e.preventDefault();
});

//Delete 
document.getElementById('products-list').addEventListener('click', function (e) {
    const ui = new UI();

    ui.deleteProducts(e.target);
});