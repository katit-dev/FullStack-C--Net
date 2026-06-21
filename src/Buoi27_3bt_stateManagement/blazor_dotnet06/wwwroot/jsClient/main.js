console.log("abc");

/*
    Toán tử : + - * / %
    dynamic type: kiểu dữ liệu sẽ phụ thuộc vào giá trị
    var,let, const: Từ khoá khai báo biến
*/

let a = 5;
console.log(typeof(a));

a = "hello ";
console.log(typeof(a));


let strHello = `abcsd ${a} xyz`;

console.log(strHello);

// '1' + '5' => '11'
// 1 + 1 => 2

// Number('1') + Number('1');
console.log(`Kết quả: ${'10' / '2'}`);

//Hàm :

/*
+Đối với C#
    void: không có giá trị trả về (không return)
    outputType: return về đúng type
+Đối với js
    có giá trị trả về thì có lệnh return 
*/

//expression function
let tinhTong = async function (a,b) {
    console.log(a+b);
}
//declaration function (hỗ trợ hoisting)
// window.tinhTong = function () {}

// function tinhTong(a,b){
    
//     return a - b;
// }

// function tinhTong(a,b){
    
//     return a + b;
// }
// console.log(tinhTong(1,3));



//Viết hàm lấy danh sách sản phẩm từ api getAllProduct

let getAllProductApi = async () => {

    let response = await fetch("https://apistore.cybersoft.edu.vn/api/Product");
    let data = await response.json();
    console.log(data);
    //JS DOM 
    let strHTML = "";
    for(let item of data.content){
        strHTML += `<div class="col-md-3 mt-2">
            <div class="card">
                <img src="${item.image}" alt="${item.alias}" class="card-img-top" />
                <div class="card-body">
                    <h3 class="card-title">${item.name} </h3>
                    <p class="card-text">${item.description}</p>
                    <button class="btn btn-dark">Detail</button>
                </div>
            </div>
        </div>
        `;
    }


    document.querySelector("#content").innerHTML += strHTML;
}
getAllProductApi();

//Application js 

/*
    localstorage: Lưu được 5mb tại client và lưu dạng key value
    .getItem('key'): lấy ra dữ liệu value từ localstorage dựa vào key
    .setItem('key'): Gán giá trị vào localstorage dựa vào key
    .removeItem('key'): Xoá giá trị localstorage dựa vào key
*/

window.setLocalStorage = () => {
    localStorage.setItem("name","Khanh Vy");
    let prod = {
        id: 1,
        name: "Iphone 14 Pro Max",
        price: 30000000
    }

    // primitive value: string, boolean, number
    // localStorage.setItem('data object', prod);
    localStorage.setItem('data object', JSON.stringify(prod));

    /*
        json -> string : JSON.stringify() <=> C#: JsonSerializer.Serialize()
        string -> json : JSON.parse() <=> C#: JsonSerializer.Deserialize()
    */


}


window.getStorage = () => {
    let sData = localStorage.getItem('data');
    console.log(sData)

    // lay json data
    let sJSON = localStorage.getItem('data object');
    console.log(sJSON);

    let jsonData = JSON.parse(sJSON);

}

window.removeStrorage = () => {
    localStorage.removeItem('data');
}

//Tạo các hàm get set remove cookie
export function setCookie(name, value, days) {
    const expires = new Date(Date.now() + days * 24 * 60 * 60 * 1000).toUTCString();
    document.cookie = `${name}=${value}; expires=${expires}; path=/`;
}

export function getCookie(name) {
    const cookies = document.cookie.split(';');
    for (let cookie of cookies) {
        const [cookieName, cookieValue] = cookie.trim().split('=');
        if (cookieName === name) {
            return cookieValue;
        }
    }
    return null;
}

export function removeCookie(name) {
    setCookie(name, '', -1);
}


setCookie('username', 'Khanh Vy', 7);




//===========================buoi26===============================


window.sayHello = async (title, name) => {
    console.log(`
        Hello ${title}
    Hello ${name}    
    `)
}

window.tinhTong = (a, b) => {
    return a + b;
}

// viet ham call api
window.fetchDataApi = async () => {
    let response = await fetch("https://apistore.cybersoft.edu.vn/api/Product");
    let data = await response.json();
    console.log(data);
}