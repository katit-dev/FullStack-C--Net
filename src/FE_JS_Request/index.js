window.getDataApi = async () => {
    console.log(axios);
    const res = await axios.get('http://localhost:5290/api/Product/GetAllProductsLinq')

    console.log(res.data);
}

window.insertProduct = async () => {
    try {
        const newProduct = {
            name: "Tra Sua Matcha",
            price: 35000,
            description: "Tra sua vi matcha ngon",
            imageUrl: "matcha.jpg"
        };

        const res = await axios.post(
            "http://localhost:5290/api/Product/InsertProductLinq",
            newProduct
        );

        console.log("Them san pham thanh cong:");
        console.log(res.data);
    } catch (error) {
        console.log("Loi khi goi API POST:");
        console.log(error);
    }
};