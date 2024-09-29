import express from 'express'

const app = express()

app.use(express.static(process.cwd() + '/public'))

app.get("/", (req,res)=>{
    res.sendFile(process.cwd() + '/public/views/index.html')
})

app.get("/products", (req, res) => {
    res.sendFile(process.cwd() + '/public/views/product.html');
});
app.listen(4321,()=>{
    console.log("Escuchando en el puerto 4321");
})