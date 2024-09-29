
const containerAllProducts = document.querySelector("#all-products")
const formCrearProduct = document.querySelector("#form-crear-product")

document.addEventListener("DOMContentLoaded", getAllProducts)
formCrearProduct.addEventListener("submit", crearProducto)

async function getAllProducts(event) {
    const request = await fetch("http://localhost:5000/api/Products",{
        method: "GET"
    })
    if(request.status == 200){
        const data = await request.json()
        data.forEach(element => {
            
            const link = document.createElement("a")
            link.href = `http://localhost:4321/products?id=${element.id}`
            link.classList.add("a-product")
            
            const article = document.createElement("article");
            article.classList.add("product");
            link.append(article)
            // Crear los elementos p para los diferentes datos del producto
            const name = document.createElement("h2");
            name.textContent = element.name;
    
            const price = document.createElement("p");
            price.classList.add("price")
            price.textContent = `$ ${element.price}`
    
            const stock = document.createElement("p");
            stock.textContent = element.stock;
    
            const description = document.createElement("p");
            description.textContent = element.description

            const image = document.createElement("img")
            if(!element.image){
                image.src = "https://upload.wikimedia.org/wikipedia/commons/6/65/No-Image-Placeholder.svg"
            }else{
                image.src = element.image
            }
            
            const containerImage = document.createElement("div")
            const containerInfo = document.createElement("picture")
            containerImage.append(image)
            containerInfo.appendChild(name);
            containerInfo.appendChild(price);
            containerInfo.appendChild(stock);
            containerInfo.appendChild(description);
            article.appendChild(containerImage)
            article.appendChild(containerInfo)
            containerAllProducts.appendChild(link)
        });
    }
}

async function crearProducto(event) {
    event.preventDefault()

    
    const dataFromForm = Object.fromEntries(new FormData(event.target))
    const request = await fetch("http://localhost:5000/api/Products",{
        method: "POST",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(dataFromForm)
    })
    if(request.status == 200){
        Swal.fire({
            title: 'Éxito!',
            text: 'Producto creado exitosamente.',
            icon: 'success',
            showConfirmButton: false, 
            timer: 2000, 
            timerProgressBar: true,
        });
        location.reload()
        return
    }
    Swal.fire({
        title: 'Error!',
        text: 'Intenta de nuevo más tarde.',
        icon: 'error',
        showConfirmButton: false, 
        timer: 2000, 
        timerProgressBar: true,
    });
}

