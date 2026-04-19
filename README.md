# TUẦN 1 – KIẾN THỨC CẦN NẮM (Note siêu ngắn)

- **Dependency Rule**
  Dependencies (phụ thuộc giữa các project) chỉ trỏ vào trong (Domain ← Application ← Infra ← API).
  Domain KHÔNG reference (tham chiếu) gì cả → Business (nghiệp vụ) độc lập hoàn toàn.

- **Entity**
  Có Identity (định danh duy nhất, thường là Id), có lifecycle (vòng đời: tạo/sửa/xóa).
  → Product, Category kế thừa `EntityBase`.

- **Value Object**
  Không Id, immutable (bất biến, tạo rồi không đổi được) ví dụ `Money`.
  → Tránh primitive obsession (lạm dụng kiểu cơ bản như string/int), đảm bảo tính nhất quán.

- **Rich Domain Model**
  Entity chứa business rules (luật nghiệp vụ) + behavior (hành vi, ví dụ `Create`, `DecreaseStock`).
  → Không phải Anemic (mô hình "thiếu máu", chỉ có getter/setter, không có logic).

- **Factory Method**
  Dùng `static Create(...)` thay constructor public (hàm khởi tạo public).
  → Enforce business rule (ép kiểm tra luật nghiệp vụ) ngay khi tạo object.

- **DomainException**
  Exception (ngoại lệ) riêng cho business rule violation (vi phạm luật nghiệp vụ).
  → Tách biệt lỗi business (nghiệp vụ) vs technical error (kỹ thuật: DB/network...).

- **Repository Interface**
  Đặt ở Domain (`IProductRepository`).
  → DIP (Dependency Inversion Principle - nguyên tắc đảo ngược phụ thuộc): Domain chỉ biết “cần gì”, Infra implement (triển khai) sau.

- **Private Constructor + private set**
  Cho EF Core map (ánh xạ) dữ liệu nhưng vẫn giữ encapsulation (đóng gói).
  → Rich model vẫn tương thích ORM (Object-Relational Mapping - công cụ map object với database).

- **Encapsulation & Immutability**
  Properties private set, chỉ thay đổi qua method (hàm trong class).
  → Bảo vệ business rules, tránh side-effect (tác dụng phụ ngoài ý muốn).

- **Aggregate (sơ lược)**
  Nhóm Entity liên quan (Product + Category).
  → Bảo vệ tính nhất quán dữ liệu (consistency: dữ liệu luôn đúng theo luật).
