Buổi 21


- component param: truyền dữ liệu từ component cha xuống component con
    - sử dụng [Parameter] để đánh dấu thuộc tính nhận dữ liệu từ cha
    VD: <Product sanPham="@item" />
    - Nhận qua RenderFragment 
    VD: <Product>
            <h3>Tiêu đề sản phẩm</h3>
            <p>Mô tả sản phẩm</p>
        </Product>
    - Lưu ý: tên của con mặc định là 
- Event callback: truyền hàm từ component cha xuống component con
    - sử dụng [Parameter] và EventCallback để đánh dấu thuộc tính nhận dữ liệu từ con
    VD: <Product OnAddToCart="@HandleAddToCart" />

    Lưu ý: 

- Ref : Lấy tham chiếu đến component con để gọi phương thức hoặc truy cập thuộc tính của nó
    - sử dụng @ref để đánh dấu component con và tạo biến tham chiếu trong component cha
    VD: <Product @ref="productRef" />
        @code {
            private Product productRef;
            private void CallChildMethod()
            {
                productRef.SomeMethod();
            }
        }
    - Lưu ý: