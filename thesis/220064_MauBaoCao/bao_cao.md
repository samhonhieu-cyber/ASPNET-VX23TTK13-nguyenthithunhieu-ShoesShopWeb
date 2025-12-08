**LỜI CẢM ƠN**

Trong suốt quá trình thực hiện đồ án “ShoesShopWeb – Website bán giày trực tuyến”, em nhận được sự hướng dẫn tận tình của quý thầy cô, sự hỗ trợ chuyên môn của bạn bè và sự động viên to lớn từ gia đình. Em xin bày tỏ lòng biết ơn sâu sắc đến quý thầy cô đã trang bị cho em kiến thức nền tảng về ASP.NET Core, Entity Framework Core, cơ sở dữ liệu PostgreSQL và phương pháp luận nghiên cứu khoa học. Những kiến thức và định hướng phương pháp này giúp em xây dựng được khung tiếp cận rõ ràng, xác định mục tiêu phù hợp và triển khai hệ thống theo trình tự khoa học.

Em trân trọng cảm ơn các thầy cô phụ trách môn học và hướng dẫn đồ án đã dành thời gian góp ý, gợi mở các góc nhìn về kiến trúc nhiều lớp, tổ chức dữ liệu và phương thức kiểm thử. Các buổi trao đổi học thuật, phản biện chuyên môn đã giúp em nhận diện sớm hạn chế, điều chỉnh thiết kế, tối ưu hóa luồng xử lý và nâng cao chất lượng mã nguồn. Sự tỉ mỉ trong từng nhận xét và sự tận tâm trong quá trình đồng hành là động lực để em kiên trì hoàn thiện sản phẩm.

Em cũng cảm ơn các bạn đồng môn đã tích cực hỗ trợ trong quá trình phát triển và kiểm thử, từ việc rà soát yêu cầu đến thử nghiệm các chức năng quản lý sản phẩm, giỏ hàng và đơn hàng. Những ý kiến phản hồi thực tiễn từ trải nghiệm người dùng đã giúp em cải thiện giao diện Razor Pages, tối ưu tương tác AJAX và điều chỉnh quy trình đặt hàng theo hướng thân thiện và hiệu quả hơn. Sự hợp tác và tinh thần chia sẻ đã tạo nên môi trường học tập tích cực, thúc đẩy tiến độ và chất lượng của đồ án.

Đặc biệt, em xin gửi lời cảm ơn đến gia đình vì luôn là chỗ dựa tinh thần vững chắc, tạo điều kiện về thời gian và môi trường học tập. Sự động viên kịp thời đã giúp em giữ vững tinh thần trong giai đoạn căng thẳng, vượt qua thách thức về kỹ thuật và quản lý thời gian. Nhờ sự đồng hành của gia đình, em có thể tập trung nghiên cứu, hiện thực hóa các hạng mục theo kế hoạch và hoàn thành đồ án đúng tiến độ.

Cuối cùng, em cảm ơn các thầy cô, bạn bè và những người dùng thử đã dành sự quan tâm và hỗ trợ đối với đề tài. Các góp ý giá trị về bảo mật (hashing mật khẩu, CSRF), về mô hình dữ liệu (biến thể sản phẩm theo màu và kích cỡ) và về cách triển khai (Docker Compose cho PostgreSQL) đã giúp sản phẩm đạt độ ổn định tốt hơn trong môi trường phát triển. Từ những trải nghiệm này, em rút ra nhiều bài học quý báu về tư duy hệ thống, quy trình làm việc và sự cẩn trọng trong kiểm thử, làm nền tảng cho các dự án sau.

**MỤC LỤC**

(Sinh viên tạo mục lục tự động khi biên soạn cuối cùng.)

**DANH MỤC HÌNH ẢNH**

(Ghi chú nơi cần chèn hình ảnh ở các mục Chương 3 và Chương 4.)

**DANH MỤC BẢNG BIỂU**

(Bảng liệt kê ở các phần yêu cầu chức năng, kiến trúc và kết quả.)

**TÓM TẮT ĐỒ ÁN**

Đồ án hiện thực một hệ thống thương mại điện tử chuyên bán giày dép với đầy đủ nghiệp vụ cốt lõi: quản lý danh mục, sản phẩm và biến thể (màu sắc, kích cỡ), giỏ hàng và đặt hàng trực tuyến, cùng cơ chế phân quyền theo vai trò (Admin, Staff, Customer). Bối cảnh lựa chọn đề tài xuất phát từ nhu cầu thực tế của cửa hàng trực tuyến về một nền tảng ổn định, dễ mở rộng và bảo trì, đáp ứng đặc thù sản phẩm thời trang có nhiều biến thể và yêu cầu trải nghiệm nhất quán. Mục tiêu là xây dựng một giải pháp có cấu trúc rõ ràng, đảm bảo tính nhất quán dữ liệu, độ tin cậy trong xử lý nghiệp vụ và trải nghiệm người dùng hợp lý trong môi trường phát triển.

Hệ thống được phát triển bằng ASP.NET Core 9.0, theo kiến trúc nhiều lớp N-Layer (Entity, DAL, BLL, Presentation), sử dụng Razor Pages cho tầng giao diện và Entity Framework Core 9.0 cho truy cập dữ liệu. Cơ sở dữ liệu PostgreSQL 16 được khởi chạy nhất quán thông qua Docker Compose nhằm đơn giản hóa việc thiết lập môi trường, quản lý cấu hình kết nối và đảm bảo khả năng tái lập. Các yêu cầu bảo mật cơ bản được hiện thực bằng cơ chế hashing mật khẩu với BCrypt và bảo vệ CSRF tích hợp. Thiết kế mô hình dữ liệu phản ánh đặc thù sản phẩm giày, với các quan hệ Category–Product–ProductVariant và Order–OrderItem, hỗ trợ thao tác CRUD, tính toàn vẹn dữ liệu và quy trình đặt hàng.

Phương pháp tiếp cận bao gồm khảo cứu tài liệu chính thống, thiết kế kiến trúc và mô hình dữ liệu, hiện thực hóa dịch vụ nghiệp vụ trong BLL, cùng kiểm thử chức năng theo luồng người dùng đại diện. Kết quả cho thấy hệ thống hoạt động ổn định trong môi trường phát triển: các chức năng CRUD vận hành đúng, giỏ hàng có tương tác AJAX, quy trình đặt hàng và quản lý đơn hàng đáp ứng yêu cầu. Báo cáo tổng kết cơ sở lý thuyết, quy trình hiện thực, mô hình cơ sở dữ liệu, kiến trúc triển khai và đánh giá kết quả; đồng thời đề xuất hướng phát triển như tích hợp cổng thanh toán, mở rộng thống kê và triển khai CI/CD.

Tổng kết lại, đồ án đã chứng minh tính khả thi của việc xây dựng một nền tảng bán giày trực tuyến theo kiến trúc nhiều lớp với công nghệ .NET hiện đại, đạt được các mục tiêu về chức năng, bảo mật cơ bản và trải nghiệm người dùng trong môi trường phát triển. Sản phẩm tạo tiền đề cho việc mở rộng theo hướng tích hợp thanh toán, nâng cấp báo cáo thống kê và tự động hóa quy trình triển khai, góp phần nâng cao chất lượng và hiệu quả vận hành của hệ thống trong các giai đoạn tiếp theo.

**MỞ ĐẦU**

1. Lý do chọn đề tài

Trong bối cảnh thương mại điện tử phát triển nhanh, các cửa hàng trực tuyến cần những hệ thống bán hàng chuyên biệt, ổn định và dễ mở rộng. Nhóm sản phẩm thời trang, đặc biệt là giày dép, có đặc thù quản lý biến thể theo màu sắc và kích cỡ, đòi hỏi thiết kế dữ liệu và quy trình nghiệp vụ rõ ràng. Đề tài ShoesShopWeb được lựa chọn để hiện thực một website bán giày trực tuyến có đầy đủ quy trình từ quản lý danh mục, sản phẩm, biến thể đến giỏ hàng và xử lý đơn hàng. Đồng thời, đề tài tạo cơ hội áp dụng công nghệ .NET hiện đại, chuẩn hóa hạ tầng cơ sở dữ liệu và rèn luyện tư duy kiến trúc phần mềm theo mô hình nhiều lớp.

Việc triển khai hệ thống trên nền ASP.NET Core giúp tận dụng hệ sinh thái phong phú, khả năng mở rộng, bảo mật tích hợp và cộng đồng hỗ trợ. Lựa chọn PostgreSQL và Docker Compose mang lại môi trường phát triển nhất quán, dễ tái lập và thuận lợi cho việc chuyển giao. Nhờ đó, đề tài vừa đáp ứng yêu cầu học thuật, vừa có tính ứng dụng thực tế.

2. Mục tiêu nghiên cứu

Mục tiêu tổng quát là thiết kế và hiện thực một website bán giày trực tuyến theo kiến trúc nhiều lớp, bảo đảm tính mô-đun, khả năng mở rộng và dễ bảo trì. Hệ thống cần đáp ứng đầy đủ nghiệp vụ cốt lõi, bao gồm quản lý danh mục, sản phẩm và biến thể (màu sắc, kích cỡ), giỏ hàng và đặt hàng, cùng cơ chế phân quyền theo vai trò để đảm bảo an toàn và kiểm soát truy cập.

Mục tiêu cụ thể là vận dụng Entity Framework Core để mô hình hóa dữ liệu và quản lý migrations, thiết lập kết nối ổn định với PostgreSQL qua Docker Compose, và xây dựng giao diện Razor Pages thân thiện, responsive. Bên cạnh đó, dự án đặt mục tiêu đảm bảo bảo mật cơ bản (hashing mật khẩu, CSRF), cung cấp trải nghiệm người dùng hợp lý và tạo nền tảng sẵn sàng cho việc tích hợp các tính năng nâng cao trong tương lai.

3. Đối tượng và phạm vi nghiên cứu

Đối tượng nghiên cứu là hệ thống thương mại điện tử chuyên bán giày, với trọng tâm vào các nghiệp vụ quản lý danh mục, sản phẩm, biến thể, giỏ hàng, đặt hàng và phân quyền người dùng. Hệ thống hướng tới phục vụ ba nhóm vai trò chính: Khách hàng, Nhân viên (Staff) và Quản trị viên (Admin), mỗi vai trò có phạm vi chức năng và mức độ truy cập khác nhau.

Phạm vi nghiên cứu tập trung vào nền tảng ASP.NET Core với Razor Pages cho giao diện, sử dụng Entity Framework Core cho truy cập dữ liệu và PostgreSQL làm cơ sở dữ liệu, triển khai qua Docker Compose để đảm bảo môi trường nhất quán. Các nội dung như tích hợp cổng thanh toán bên thứ ba, tối ưu SEO nâng cao, phân tích dữ liệu chuyên sâu và triển khai CI/CD toàn diện được ghi nhận là hướng phát triển, chưa nằm trong phạm vi hiện thực của đồ án này.

4. Phương pháp nghiên cứu

Phương pháp nghiên cứu bao gồm tiếp cận từ nền tảng lý thuyết và thực nghiệm. Trước hết, em khảo cứu các tài liệu chính thức của ASP.NET Core, Entity Framework Core, PostgreSQL và Docker Compose để nắm vững đặc điểm, mô hình vận hành và thực hành tốt. Trên cơ sở đó, em xây dựng kiến trúc hệ thống theo mô hình N-Layer, thiết kế mô hình dữ liệu phù hợp với đặc thù sản phẩm giày (biến thể theo màu, kích cỡ) và các quan hệ giữa các thực thể như danh mục, sản phẩm, đơn hàng, người dùng.

Quá trình hiện thực được triển khai theo hướng gia tăng, chia nhỏ chức năng, tích hợp và kiểm thử theo luồng người dùng đại diện (Customer, Staff, Admin). Các báo cáo tiến độ tuần giúp ghi nhận trạng thái, rủi ro và điều chỉnh kế hoạch đúng thời điểm. Bên cạnh kiểm thử chức năng, em cũng xem xét các yếu tố phi chức năng như bảo mật cơ bản (hashing mật khẩu, CSRF), tính ổn định và trải nghiệm người dùng, nhằm đảm bảo hệ thống đạt yêu cầu ở mức độ triển khai thực tế.

5. Ý nghĩa đề tài

Ý nghĩa học thuật của đề tài thể hiện ở việc vận dụng có hệ thống các kiến thức về kiến trúc phần mềm nhiều lớp, mô hình hóa dữ liệu với EF Core và thiết lập môi trường triển khai bằng Docker Compose. Việc hiện thực hóa một bài toán thương mại điện tử với đặc thù sản phẩm có nhiều biến thể giúp củng cố năng lực phân tích yêu cầu, thiết kế lược đồ cơ sở dữ liệu và tổ chức tầng nghiệp vụ theo nguyên tắc tách biệt trách nhiệm. Quá trình nghiên cứu và kiểm thử theo luồng người dùng đại diện cũng góp phần hoàn thiện kỹ năng đánh giá phi chức năng như bảo mật, tính ổn định và trải nghiệm người dùng.

Ý nghĩa thực tiễn nằm ở khả năng xây dựng một nền tảng bán giày trực tuyến có cấu trúc rõ ràng, dễ mở rộng và dễ bảo trì, phù hợp với nhu cầu cửa hàng thương mại điện tử hiện nay. Hệ thống tạo tiền đề cho việc tích hợp các dịch vụ thanh toán, mở rộng báo cáo thống kê và tự động hóa quy trình triển khai, qua đó nâng cao hiệu quả vận hành và giảm chi phí bảo trì. Đề tài đồng thời gợi mở một quy trình làm việc có thể tái sử dụng cho các dự án web khác trong cùng lĩnh vực.

# CHƯƠNG 1: TỔNG QUAN

Chương này trình bày mục tiêu và bối cảnh của đề tài, kiến trúc tổng thể của hệ thống, cùng một số nội dung nền tảng gồm yêu cầu và phạm vi, công nghệ và môi trường, dữ liệu và giả định nghiệp vụ, rủi ro và biện pháp giảm thiểu. Mục tiêu của chương là định vị vấn đề, làm rõ phương hướng hiện thực và chuẩn hóa thuật ngữ sử dụng trong các phần sau.

## 1. Mục tiêu và bối cảnh

Mục tiêu của đề tài là xây dựng một hệ thống thương mại điện tử chuyên bán giày, đáp ứng đầy đủ nghiệp vụ cốt lõi (quản lý danh mục, sản phẩm và biến thể; giỏ hàng; đặt hàng) và phân quyền người dùng theo vai trò (Admin, Staff, Customer). Bối cảnh lựa chọn đề tài xuất phát từ nhu cầu thực tế của cửa hàng trực tuyến về một nền tảng ổn định, dễ mở rộng và dễ bảo trì; đồng thời sản phẩm thời trang có nhiều biến thể theo màu sắc và kích cỡ đặt ra yêu cầu thiết kế dữ liệu và quy trình nghiệp vụ rõ ràng.

## 2. Kiến trúc tổng thể của hệ thống

Hệ thống áp dụng kiến trúc nhiều lớp (N-Layer) gồm: Entity (mô hình dữ liệu, DTOs, Enums), Data Access Layer (DAL – truy cập dữ liệu, repositories, migrations), Business Logic Layer (BLL – dịch vụ nghiệp vụ, validators) và Presentation (Razor Pages – giao diện người dùng, ViewModels, Helpers). Cách tổ chức này tách biệt trách nhiệm, nâng cao khả năng kiểm thử, mở rộng và bảo trì, đồng thời hỗ trợ phân quyền chức năng theo vai trò.

(Ghi chú: Nơi chèn ảnh minh họa kiến trúc tổng thể hệ thống. Tên ảnh gợi ý: `architecture-overview.png`.)

## 3. Yêu cầu hệ thống và phạm vi triển khai

Yêu cầu hệ thống tập trung vào các chức năng hiển thị và quản lý sản phẩm, biến thể (màu/size), giỏ hàng, đơn hàng và phân quyền theo vai trò. Phạm vi triển khai trong đồ án tập trung vào ASP.NET Core 9.0 (Razor Pages) cho giao diện, EF Core 9.0 cho truy cập dữ liệu và PostgreSQL 16 cho cơ sở dữ liệu, chạy qua Docker Compose để đảm bảo môi trường nhất quán. Các nội dung như tích hợp cổng thanh toán, SEO nâng cao và phân tích dữ liệu chuyên sâu được ghi nhận là hướng phát triển tiếp theo.

## 4. Công nghệ và môi trường

Backend sử dụng ASP.NET Core 9.0; giao diện sử dụng Razor Pages kết hợp Bootstrap 5 và JavaScript; truy cập dữ liệu qua Entity Framework Core 9.0. Cơ sở dữ liệu PostgreSQL 16 được khởi chạy nhất quán bằng Docker Compose, cấu hình kết nối quản lý trong `appsettings.json` và biến môi trường. Bảo mật cơ bản bảo đảm bằng hashing mật khẩu (BCrypt) và cơ chế CSRF.

## 5. Dữ liệu và giả định nghiệp vụ

Mô hình dữ liệu phản ánh đặc thù sản phẩm giày với các quan hệ Category–Product–ProductVariant và Order–OrderItem. Giả định nghiệp vụ gồm: biến thể gắn với từng sản phẩm; tồn kho quản lý theo biến thể; đơn hàng gồm nhiều dòng hàng với số lượng và giá đơn vị; vai trò người dùng quyết định phạm vi thao tác (xem/CRUD/duyệt đơn hàng).

## 6. Rủi ro và biện pháp giảm thiểu

Rủi ro chủ yếu gồm: sai lệch mô hình dữ liệu so với yêu cầu nghiệp vụ; lỗi tương tác AJAX ở giỏ hàng; cấu hình môi trường Docker chưa nhất quán; và các vấn đề bảo mật cơ bản. Biện pháp giảm thiểu: kiểm thử theo luồng người dùng đại diện; rà soát lược đồ và migrations; sử dụng cấu hình chuẩn cho Docker Compose; áp dụng hashing mật khẩu và CSRF; theo dõi tiến độ và phản hồi định kỳ để điều chỉnh kịp thời.

# CHƯƠNG 2: NGHIÊN CỨU LÝ THUYẾT

(Nếu bỏ Tổng quan, thì phần này coi như Chương 1.)

Chương này trình bày riêng rẽ các cơ sở lý thuyết được sử dụng trong đồ án, bao gồm kiến trúc N-Layer, Razor Pages, Entity Framework Core, PostgreSQL, Docker Compose và các cơ chế bảo mật (BCrypt, CSRF, phân quyền theo vai trò). Mỗi mục mô tả khái niệm, đặc điểm, ưu/nhược điểm, và nêu rõ lý do áp dụng trong phạm vi dự án.

## 2.1. Kiến trúc N-Layer

Kiến trúc N-Layer tách biệt rõ trách nhiệm giữa các tầng, qua đó nâng cao khả năng bảo trì, kiểm thử và mở rộng. Tầng Presentation hiện thực giao diện bằng Razor Pages và PageModel, trao đổi dữ liệu qua ViewModel. Tầng Business Logic Layer (BLL) tập trung các quy tắc nghiệp vụ thông qua dịch vụ, kèm validators và helpers. Tầng Data Access Layer (DAL) đảm nhiệm truy cập dữ liệu với Repository, cấu hình DbContext và quản lý migrations. Tầng Entity định nghĩa mô hình dữ liệu, DTO và Enums dùng chung.

Luồng xử lý điển hình: người dùng tương tác trang Razor, PageModel tiếp nhận yêu cầu và gọi dịch vụ ở BLL; dịch vụ áp dụng quy tắc (ví dụ kiểm tra tồn kho, tính giá), phối hợp một hoặc nhiều Repository ở DAL để đọc/ghi dữ liệu, bao bọc giao dịch khi cần nhằm bảo đảm toàn vẹn. Dữ liệu qua lại giữa các tầng bằng ViewModel/DTO để tránh rò rỉ chi tiết mô hình, hạn chế phụ thuộc chặt chẽ và cho phép thay thế từng tầng với tác động tối thiểu.

Ưu điểm của cách tiếp cận này là dễ kiểm thử (có thể mock Repository), mở rộng chức năng theo chiều ngang và kiểm soát tốt thay đổi. Đánh đổi là tăng nhu cầu phối hợp và độ phức tạp; do đó cần tuân thủ phụ thuộc một chiều, áp dụng Dependency Injection và chuẩn hóa hợp đồng giữa các tầng (interfaces, DTOs). Kiến trúc này cũng thuận lợi để tích hợp các mối quan tâm cắt ngang như caching, logging và phân quyền.

(Ghi chú: Có thể chèn ảnh minh họa luồng tương tác giữa các tầng N-Layer. Tên ảnh gợi ý: `nlayer-overview.png`.)

## 2.2. Razor Pages

Razor Pages là mô hình phát triển giao diện theo định hướng trang (page‑centric), trong đó mỗi trang gồm cặp tệp .cshtml và lớp PageModel tương ứng. Cơ chế Model Binding/Validation, Tag Helpers và Routing theo cấu trúc thư mục hỗ trợ xây dựng biểu mẫu, xử lý các phương thức OnGet/OnPost, xác thực dữ liệu và phát sinh antiforgery token mặc định, nhờ đó giảm mã lặp và bảo đảm an toàn cho thao tác gửi biểu mẫu.

Trong phạm vi dự án, Razor Pages được lựa chọn vì phù hợp với các chức năng CRUD và các luồng tương tác tuyến tính của người dùng (danh sách, chi tiết, thêm, sửa, xóa). Mô hình này giúp tách bạch trình bày và xử lý, dễ bảo trì, thuận tiện tích hợp DI/EF Core ở mức PageModel, hỗ trợ cập nhật bất đồng bộ (AJAX/partial render) và cấu hình phân quyền theo từng trang, qua đó giữ cho kiến trúc rõ ràng và nhất quán.

(Ghi chú: Có thể chèn ảnh mô tả luồng xử lý một yêu cầu trong Razor Pages. Tên ảnh gợi ý: `razor-pages-flow.png`.)

## 2.3. Entity Framework Core

Entity Framework Core (EF Core) là ORM của .NET dùng để ánh xạ mô hình hướng đối tượng sang cơ sở dữ liệu quan hệ. Trong dự án, EF Core được sử dụng với DbContext, bộ migrations và LINQ để hiện thực các quan hệ một‑nhiều và nhiều‑nhiều giữa các thực thể như Category, Product, ProductVariant, Order và OrderItem. Cơ chế tracking/no‑tracking và các chiến lược nạp dữ liệu (eager/lazy/explicit) giúp cân bằng giữa tính nhất quán và hiệu năng khi truy vấn, đồng thời giữ cho logic nghiệp vụ tách biệt khỏi chi tiết SQL.

Các mẫu sử dụng chính gồm: truy vấn có phân trang và lọc (search/filter) qua LINQ; thao tác cập nhật/ghi nhận sự thay đổi với ChangeTracker; và quản lý lược đồ cơ sở dữ liệu thông qua migrations nhằm đồng bộ cấu trúc theo vòng đời phát triển. Để tối ưu, các truy vấn chỉ đọc dùng AsNoTracking, các thao tác ghi gói trong giao dịch khi cần đảm bảo toàn vẹn, kết hợp chỉ mục khóa ngoại/phổ biến để cải thiện hiệu năng. EF Core được chọn vì năng suất cao, hỗ trợ hệ sinh thái .NET và nhà cung cấp PostgreSQL ổn định, phù hợp cho yêu cầu CRUD và mở rộng sau này.

(Ghi chú: Chèn ảnh lược đồ quan hệ giữa các thực thể chính. Tên ảnh gợi ý: `efcore-entities.png`.)

## 2.4. PostgreSQL

PostgreSQL 16 là hệ quản trị cơ sở dữ liệu quan hệ tuân thủ ACID với cơ chế MVCC tối ưu cho truy cập đồng thời. Hệ thống chỉ mục đa dạng (B‑tree, GIN, GiST, BRIN) cùng các ràng buộc toàn vẹn (khóa chính/ngoại, unique, check) giúp bảo đảm tính nhất quán dữ liệu và hiệu năng truy vấn ở các kiểu tải khác nhau. Các tính năng như transaction, savepoint, view/materialized view, trigger và policy (Row‑Level Security) tạo nền tảng vững chắc để hiện thực nghiệp vụ an toàn, có kiểm soát.

Về khả năng mở rộng, PostgreSQL hỗ trợ kiểu dữ liệu phong phú (JSONB, mảng, range, enum, composite), full‑text search tích hợp và hệ sinh thái extension mạnh (PostGIS, pg_trgm, citext, hstore, FDW). JSONB kết hợp chỉ mục GIN cho phép truy vấn thuộc tính bán cấu trúc hiệu quả; pg_trgm hỗ trợ tìm kiếm theo tương đồng/ký tự, citext giúp so khớp không phân biệt hoa thường. Trong đồ án, PostgreSQL được dùng theo mô hình quan hệ chuẩn với các bảng Category, Product, ProductVariant, User, Role, Order, OrderItem; áp dụng khóa ngoại và chỉ mục trên các cột truy vấn phổ biến (ví dụ khóa ngoại, SKU, tên sản phẩm). Các thao tác đặt hàng được gói trong transaction để bảo đảm toàn vẹn, và Docker Compose được dùng để khởi chạy cơ sở dữ liệu ổn định, dễ tái lập môi trường.

Các điểm nổi bật của PostgreSQL so với SQL Server (trong bối cảnh đồ án):

- Giấy phép/Chi phí: mã nguồn mở, miễn phí; không ràng buộc license trong giai đoạn phát triển và triển khai thử nghiệm.
- JSONB và chỉ mục: JSONB kèm chỉ mục GIN và toán tử phong phú giúp truy vấn thuộc tính linh hoạt; ở SQL Server, JSON lưu dưới dạng văn bản và thường cần cột tính toán để lập chỉ mục hiệu quả.
- Hệ sinh thái extension: phong phú với pg_trgm (tìm kiếm tương đồng), citext (so khớp không phân biệt hoa thường), FDW, PostGIS… giúp mở rộng tính năng theo nhu cầu; SQL Server ít extension cộng đồng tương đương.
- Concurrency (MVCC): đọc không khóa mặc định, phù hợp các truy vấn liệt kê sản phẩm; SQL Server thường cần bật RCSI/SNAPSHOT để đạt hành vi tương tự.
- Docker & đa nền tảng: image chính thức nhẹ, chạy tốt trên macOS/Linux/Windows và khởi chạy nhanh với Docker Compose; image SQL Server thường nặng hơn.
- Kiểu dữ liệu: hỗ trợ mảng, range, enum, composite… thuận lợi khi mô hình hóa thuộc tính/biến thể; SQL Server thiếu một số kiểu tương đương trực tiếp.

Tổng kết: Trong phạm vi đồ án, PostgreSQL nổi trội ở chi phí bằng không, bộ tính năng phong phú cho dữ liệu bán cấu trúc (JSONB) và hệ extension đa dạng; kết hợp khả năng chạy container nhẹ giúp đơn giản hóa môi trường phát triển. SQL Server vẫn là lựa chọn mạnh ở hệ sinh thái công cụ quản trị (SSMS, Azure) và dịch vụ tích hợp; tuy nhiên các lợi thế kể trên của PostgreSQL phù hợp hơn với mục tiêu tối giản chi phí và tối ưu hoá triển khai đa nền tảng qua Docker Compose của đồ án.

(Ghi chú: Ảnh Diagram CSDL toàn màn hình sẽ được chèn ở Chương 3.3. Tên ảnh gợi ý: `db-diagram.png`.)

## 2.5. Docker Compose

Docker Compose được sử dụng để khởi chạy PostgreSQL trong môi trường phát triển theo cách nhất quán và có thể tái lập. Tệp cấu hình lựa chọn image `postgres:16-alpine` nhằm giảm dung lượng và tăng tốc độ khởi động; chính sách `restart: unless-stopped` giúp container tự khởi động lại khi gặp sự cố. Cách tiếp cận một dịch vụ cơ sở dữ liệu độc lập giúp nhóm phát triển trên macOS/Linux/Windows có cùng nền tảng, hạn chế sai lệch “works‑on‑my‑machine”.

Cấu hình dùng biến môi trường với giá trị mặc định (cú pháp `${VAR:-default}`) để đặt tên CSDL, tài khoản, mật khẩu và cổng lắng nghe; ánh xạ cổng `${POSTGRES_PORT:-5432}:5432` để linh hoạt khi máy đã dùng cổng 5432. Dữ liệu được lưu bền trên volume `postgres_data`, thư mục dữ liệu nội bộ được đặt qua `PGDATA` để tách biệt rõ ràng. Healthcheck sử dụng `pg_isready` nhằm kiểm tra trạng thái sẵn sàng; dịch vụ tham gia mạng bridge `shoesshop_network` để cô lập lưu lượng. Khi ứng dụng .NET chạy cục bộ, chuỗi kết nối trỏ đến `localhost` và cổng đã ánh xạ, hoặc tham chiếu các biến môi trường tương ứng trong `appsettings.json`.

Trong vận hành, Compose cho phép tùy biến thông qua tệp `.env` mà không cần sửa YAML; khuyến nghị đặt mật khẩu ở biến môi trường thay vì hard‑code. Khi chuyển sang môi trường dài hạn, cần bổ sung cơ chế sao lưu/khôi phục volume, chính sách bảo mật (role/permission) và giám sát tài nguyên container; đồng thời có thể mở rộng Compose để thêm công cụ quản trị tùy chọn (Adminer/pgAdmin) khi cần.

(Ghi chú: Có thể chèn ảnh minh họa vòng đời container và healthcheck. Tên ảnh gợi ý: `docker-compose-services.png`.)

## 2.6. Bảo mật cơ bản: BCrypt, CSRF và phân quyền

Hệ thống lưu trữ mật khẩu theo cơ chế băm một chiều với BCrypt, sử dụng salt ngẫu nhiên và tham số chi phí (work factor) để tăng độ khó khi tấn công vét cạn. Cách tiếp cận này giúp vô hiệu hóa khả năng khôi phục mật khẩu gốc từ dữ liệu băm, đồng thời giảm thiểu tác động khi xảy ra rò rỉ cơ sở dữ liệu. Thành phần hiện thực tại `ShoesShopWeb.BLL/Helpers/PasswordHasher.cs` bao gói logic tạo băm và xác minh, tách biệt chi tiết thuật toán khỏi phần còn lại của ứng dụng nhằm dễ bảo trì và kiểm thử.

Đối với bảo vệ khỏi tấn công giả mạo yêu cầu liên trang (CSRF), Razor Pages tích hợp antiforgery token vào biểu mẫu và xác minh trên mỗi yêu cầu POST. Token được gắn với phiên người dùng, được kết xuất tự động qua Tag Helpers và kiểm tra ở phía máy chủ, ngăn chặn kịch bản kẻ tấn công lợi dụng trình duyệt nạn nhân gửi yêu cầu trái phép. Kết hợp với xác thực người dùng và cookie cấu hình an toàn (HttpOnly, Secure), cơ chế này tạo lớp phòng thủ quan trọng cho các thao tác ghi dữ liệu như thêm vào giỏ hàng, cập nhật sản phẩm hay duyệt đơn hàng.

Phân quyền dựa trên vai trò (Role‑Based Authorization) được áp dụng nhất quán ở tầng trình bày, giới hạn truy cập các trang và thao tác nhạy cảm theo ba vai trò chính: Admin, Staff và Customer. Các quy tắc ủy quyền có thể đặt ở mức trang hoặc thư mục trang, giúp kiểm soát rõ phạm vi chức năng mỗi vai trò; đồng thời có thể mở rộng sang mô hình policy‑based để diễn đạt điều kiện phức tạp hơn khi cần. Cách tiếp cận theo vai trò giúp đơn giản hóa quản trị, tăng khả năng tuân thủ và giảm rủi ro lộ lọt dữ liệu nội bộ.

(Ghi chú: Có thể chèn ảnh sơ đồ quyền truy cập theo vai trò. Tên ảnh gợi ý: `rbac-overview.png`.)

# CHƯƠNG 3: HIỆN THỰC HÓA NGHIÊN CỨU

Chương này mô tả yêu cầu, thiết kế, cơ sở dữ liệu và kiến trúc triển khai của hệ thống.

## 3.1. Mô tả bài toán

Bài toán đặt ra là xây dựng một hệ thống thương mại điện tử chuyên bán giày, cho phép người dùng cuối duyệt, tìm kiếm và lựa chọn sản phẩm theo danh mục, màu sắc và kích cỡ, đồng thời hỗ trợ quy trình đặt hàng trọn vẹn. Hệ thống phải đảm bảo trải nghiệm nhất quán từ trang danh sách đến chi tiết sản phẩm, giỏ hàng và thanh toán, với dữ liệu sản phẩm có nhiều biến thể được mô hình hóa đúng đắn để tránh nhầm lẫn về tồn kho và giá. Kiến trúc triển khai cần ổn định, dễ mở rộng và dễ bảo trì nhằm đáp ứng yêu cầu học thuật lẫn ứng dụng thực tế.

Ở góc độ khách hàng, hệ thống cho phép đăng ký/đăng nhập, xem danh sách sản phẩm theo phân trang, lọc và tìm kiếm theo từ khóa, truy cập trang chi tiết để chọn biến thể phù hợp (màu, size) và thêm vào giỏ. Giỏ hàng hỗ trợ cập nhật số lượng theo thời gian thực (AJAX), xóa mục và tiến hành đặt hàng; người dùng có thể xem lại lịch sử đơn hàng sau khi hoàn tất. Các yêu cầu phi chức năng bao gồm giao diện responsive, tính ổn định trong môi trường phát triển và thời gian phản hồi chấp nhận được cho các thao tác thường gặp.

Ở góc độ quản trị, nhân viên và quản trị viên có quyền truy cập bảng điều khiển thống kê cơ bản, quản lý danh mục, sản phẩm và biến thể, quản lý người dùng và đơn hàng. Hệ thống áp dụng phân quyền theo vai trò để bảo vệ các thao tác nhạy cảm, bổ sung cơ chế phòng ngừa xóa dữ liệu ngoài ý muốn và hỗ trợ sinh mã SKU tự động nhằm chuẩn hóa quản lý sản phẩm. Phạm vi hiện thực tập trung vào các nghiệp vụ cốt lõi nêu trên; các chức năng nâng cao như tích hợp cổng thanh toán hoặc báo cáo phân tích chuyên sâu được ghi nhận là hướng phát triển tiếp theo.

(Ghi chú: Phần này có thể cần sơ đồ luồng người dùng và use case; chèn ảnh “Sơ đồ use case người dùng hệ thống” nếu có.)

## 3.2. Yêu cầu chức năng

Bảng 1. Tóm tắt các chức năng chính theo vai trò

| Vai trò     | Chức năng          | Mô tả ngắn                             |
| ----------- | ------------------ | -------------------------------------- |
| Customer    | Đăng ký/Đăng nhập  | Tạo tài khoản, đăng nhập hệ thống      |
| Customer    | Xem sản phẩm       | Phân trang, lọc, tìm kiếm theo từ khóa |
| Customer    | Giỏ hàng           | Thêm/Xóa/Sửa số lượng; AJAX cập nhật   |
| Customer    | Đặt hàng           | Tạo đơn hàng; xem lịch sử đơn hàng     |
| Staff/Admin | Dashboard          | Thống kê sản phẩm/đơn hàng cơ bản      |
| Staff/Admin | Quản lý danh mục   | CRUD danh mục sản phẩm                 |
| Staff/Admin | Quản lý sản phẩm   | CRUD sản phẩm, biến thể màu/size       |
| Staff/Admin | Quản lý khách hàng | Danh sách và thông tin người dùng      |
| Staff/Admin | Quản lý đơn hàng   | Duyệt, cập nhật trạng thái             |

Yêu cầu phi chức năng: hiệu năng chấp nhận được trong môi trường localhost, bảo mật cơ bản (hashing, CSRF), giao diện responsive.

## 3.3. Mô hình cơ sở dữ liệu

- Thành phần dữ liệu chính: Category, Product, ProductVariant (màu sắc/kích thước), User, Role, Order, OrderItem.
- Quan hệ cơ bản: Category–Product (1–n), Product–ProductVariant (1–n), Order–OrderItem (1–n), User–Order (1–n). Có thể có bảng mapping cho phân quyền nếu sử dụng ASP.NET Identity hoặc cơ chế tương tự.

Mô hình tập trung phản ánh đặc thù của sản phẩm có nhiều biến thể. Mỗi `Product` thuộc một `Category` và có nhiều `ProductVariant`, trong đó biến thể lưu thuộc tính màu/size, tồn kho (`Stock`) và chênh lệch giá (`PriceDelta`) so với giá cơ bản (`BasePrice`). Phép tính giá bán của biến thể được xác định từ `BasePrice` cộng/trừ `PriceDelta`, cho phép linh hoạt theo vật liệu/kích cỡ. Toàn vẹn dữ liệu được đảm bảo qua khóa ngoại (ví dụ `ProductVariant.ProductId → Product.Id`) và ràng buộc `NOT NULL` trên các cột nhận diện.

(Ghi chú: Chèn ảnh Diagram CSDL, toàn màn hình, tên file gợi ý: `db-diagram.png`.)

Mô tả từng bảng (ví dụ tối giản):

- Category: Id, Name, Description.
- Product: Id, Name, CategoryId, Description, BasePrice, SKU.
- ProductVariant: Id, ProductId, Color, Size, Stock, PriceDelta.
- User: Id, Email, PasswordHash, DisplayName, Role.
- Order: Id, UserId, CreatedAt, Status, Total.
- OrderItem: Id, OrderId, ProductVariantId, Quantity, UnitPrice.

Mô tả chi tiết từng thực thể:

- Category: đại diện nhóm sản phẩm (ví dụ: Sneaker, Sandal, Boots), dùng để tổ chức trình bày và lọc. Trường `Name` là duy nhất trong phạm vi cửa hàng để tránh trùng lặp; có thể bổ sung `Description` cho mục đích SEO và hiển thị.

- Product: mô tả sản phẩm cơ sở trước khi phân tách thành biến thể. Mỗi sản phẩm có `CategoryId`, `Name`, `Description`, `BasePrice` và `SKU` để phục vụ quản lý kho và tra cứu. `SKU` được sinh theo quy ước nhằm đảm bảo tính duy nhất và thuận tiện khi đối soát; `BasePrice` là nền tảng cho phép định giá biến thể.

- ProductVariant: nắm giữ các thuộc tính cụ thể như `Color` và `Size`, kèm `Stock` để quản lý tồn kho theo biến thể, và `PriceDelta` để điều chỉnh giá bán so với `BasePrice`. Khóa ngoại `ProductId` liên kết biến thể với sản phẩm mẹ; có thể áp dụng ràng buộc duy nhất trên cặp (`ProductId`, `Color`, `Size`) để ngăn trùng lặp biến thể.

- User: đại diện khách hàng hoặc nhân sự nội bộ, gồm `Email`, `PasswordHash`, `DisplayName` và `Role` (hoặc liên kết bảng `Role`). `Email` được dùng để đăng nhập; nên chuẩn hóa so khớp không phân biệt hoa thường và đảm bảo duy nhất. `PasswordHash` lưu theo cơ chế BCrypt; thông tin hồ sơ có thể mở rộng thêm địa chỉ, số điện thoại.

- Role: định nghĩa vai trò hệ thống như `Admin`, `Staff`, `Customer`, phục vụ phân quyền truy cập. Có thể liên kết nhiều‑nhiều với `User` nếu cần gán đa vai trò; trong phạm vi đồ án, mô hình một vai trò/người dùng là đủ.

- Order: ghi nhận đơn hàng với `UserId`, thời điểm tạo `CreatedAt`, `Status` (ví dụ: Pending, Confirmed, Shipped, Canceled) và `Total`. Tổng đơn được tính từ các dòng `OrderItem` trong transaction để bảo đảm toàn vẹn; trạng thái đơn hàng hỗ trợ luồng duyệt/cập nhật của nhân viên.

- OrderItem: dòng hàng thuộc một đơn hàng, liên kết `OrderId` và `ProductVariantId`, chứa `Quantity` và `UnitPrice` tại thời điểm đặt hàng. Việc lưu `UnitPrice` ở thời điểm giao dịch giúp đảm bảo tính bất biến của hoá đơn dù giá biến thể thay đổi sau này; ràng buộc `Quantity > 0` và kiểm tra `Stock` là cần thiết để ngăn oversell.

Chỉ mục được đề xuất trên các khóa ngoại (`CategoryId`, `ProductId`, `OrderId`, `ProductVariantId`) và các cột tìm kiếm phổ biến như `Product.Name` và `Product.SKU` để tối ưu liệt kê và tra cứu. Ràng buộc `Quantity > 0` cho `OrderItem` và kiểm soát tồn kho ở mức `ProductVariant.Stock` giúp ngăn đặt hàng vượt quá số lượng. Trường `Order.Total` có thể được tính từ tổng `Quantity × UnitPrice` của các dòng `OrderItem`, kiểm tra nhất quán trong transaction khi tạo/ cập nhật đơn hàng. Với PostgreSQL, có thể xem xét `citext` cho email (so khớp không phân biệt hoa thường) và sử dụng chỉ mục phù hợp để cải thiện hiệu năng truy vấn.

## 3.4. Lược đồ Use case / DFD

(Ghi chú: Nếu cần sơ đồ, chèn ảnh “Use case tổng quan hệ thống” hoặc “DFD mức 0/1” tùy chọn.)

## 3.5. Kiến trúc hệ thống

Công nghệ và môi trường:

- Backend: ASP.NET Core 9.0; BLL thực thi logic nghiệp vụ; DAL giao tiếp database qua EF Core 9.0.
- Frontend: Razor Pages, Bootstrap 5, JavaScript; thư mục `Pages/` chứa các trang như `Products`, `Cart`, `Orders`, `Staff`.
- Database: PostgreSQL 16 chạy bằng Docker Compose; kết nối cấu hình trong `appsettings.json`.

(Ghi chú: Có thể chèn ảnh “Kiến trúc N-Layer của dự án”.)

Kiến trúc áp dụng mô hình nhiều lớp (N‑Layer) để tách biệt trách nhiệm. Tầng Presentation hiện thực giao diện với Razor Pages: mỗi trang gồm file `.cshtml` và lớp `PageModel` xử lý các phương thức `OnGet/OnPost`, trao đổi dữ liệu qua `ViewModels`. Tầng BLL tập trung quy tắc nghiệp vụ (ví dụ: kiểm tra tồn kho, tính giá bán theo `BasePrice` và `PriceDelta`, xác thực dữ liệu đầu vào) dưới dạng services/validators. Tầng DAL sử dụng EF Core với `DbContext`, repository và migrations để truy cập, ánh xạ và quản lý lược đồ cơ sở dữ liệu. Tầng Entity định nghĩa các `Models`, `DTOs`, `Enums` dùng chung giữa các tầng, giúp chuẩn hóa hợp đồng dữ liệu.

Luồng điển hình: yêu cầu từ người dùng tới một trang Razor, `PageModel` gọi service ở BLL để thực thi nghiệp vụ; service phối hợp repository ở DAL để đọc/ghi dữ liệu, gói thao tác ghi trong transaction khi cần (ví dụ tạo đơn hàng kèm các dòng `OrderItem` và trừ tồn `ProductVariant.Stock`). Dữ liệu trả về được chuyển thành `ViewModel` để trình bày, tránh rò rỉ chi tiết mô hình nội bộ. Các mối quan tâm cắt ngang (logging, xử lý lỗi, phân quyền) được đặt ở tầng biên: middleware/filters cho kiểm soát chung, attributes/policies cho ủy quyền trang, logger DI cho ghi nhận sự kiện nghiệp vụ.

Khía cạnh vận hành: cấu hình kết nối PostgreSQL và các thông số ứng dụng đặt trong `appsettings.json` và biến môi trường; DI đăng ký `DbContext`, services BLL và repository DAL trong `Program.cs`. Migrations quản lý vòng đời lược đồ, đảm bảo đồng bộ với code qua các lần phát triển; static files (CSS/JS/lib) phục vụ từ `wwwroot`, giao diện responsive với Bootstrap. Bảo mật cơ bản gồm hashing mật khẩu (BCrypt), antiforgery token cho POST trong Razor Pages và phân quyền theo vai trò cho khu vực quản trị (`Staff`, `Admin`). Ghi log và xử lý lỗi sử dụng pipeline ASP.NET Core (developer exception page trong dev), kết hợp thông báo thân thiện trên giao diện để nâng cao trải nghiệm.

# CHƯƠNG 4: KẾT QUẢ NGHIÊN CỨU

Sau khi hoàn tất quá trình xây dựng, hệ thống đã được triển khai thành công trên môi trường phát triển tại địa chỉ `https://localhost:7114`. Ứng dụng hoạt động ổn định với giao diện responsive hiển thị tốt trên các thiết bị di động, tablet và desktop. Phần này trình bày chi tiết kết quả theo từng luồng chức năng chính từ góc nhìn người dùng, kèm theo ghi chú vị trí cần chèn hình ảnh minh họa để thể hiện trải nghiệm và giao diện hệ thống.

(Ghi chú chung về hình ảnh: Tất cả ảnh chụp màn hình cần hiển thị đầy đủ thanh địa chỉ URL https://localhost:7114, thời gian chụp và vai trò người dùng đang đăng nhập.)

## 4.1. Luồng chức năng người dùng (Customer)

### 4.1.1. Luồng duyệt và tìm kiếm sản phẩm

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang danh sách:** Người dùng truy cập website và vào trang danh sách sản phẩm. Trang hiển thị toàn bộ sản phẩm có sẵn trong cửa hàng.

2. **Bước 2 - Xem danh sách ban đầu:** Màn hình hiển thị:

   - Danh sách sản phẩm với hình ảnh, tên, giá và nút "Xem chi tiết" (mặc định hiển thị 12 sản phẩm/trang)
   - Bộ lọc bên trái gồm: Danh mục (Categories), Kích cỡ (Sizes), Màu sắc (Colors), Khoảng giá (Price Range)
   - Thanh sắp xếp phía trên với các tùy chọn: Giá tăng dần, Giá giảm dần, Mới nhất
   - Thanh phân trang phía dưới với thông tin "Showing X-Y of Z products"

3. **Bước 3 - Tìm kiếm theo từ khóa:** Người dùng có thể nhập từ khóa (ví dụ: "Nike", "Sneakers") vào ô tìm kiếm và nhấn Enter. Trang sẽ tự động làm mới và hiển thị các sản phẩm có tên hoặc mô tả khớp với từ khóa.

4. **Bước 4 - Lọc sản phẩm:** Người dùng chọn các tiêu chí lọc:

   - Chọn một hoặc nhiều danh mục (ví dụ: Running Shoes, Basketball Shoes)
   - Chọn kích cỡ mong muốn (ví dụ: 39, 40, 41)
   - Chọn màu sắc (ví dụ: Đen, Trắng, Đỏ)
   - Kéo thanh trượt hoặc nhập khoảng giá mong muốn (ví dụ: 500,000đ - 1,000,000đ)

   Sau khi chọn, người dùng nhấn nút "Áp dụng bộ lọc". Trang tự động cập nhật và chỉ hiển thị các sản phẩm phù hợp với tiêu chí đã chọn.

5. **Bước 5 - Sắp xếp kết quả:** Người dùng có thể thay đổi thứ tự hiển thị bằng cách chọn tùy chọn sắp xếp (Giá tăng dần, Giá giảm dần, Mới nhất). Danh sách sản phẩm sẽ được sắp xếp lại theo tiêu chí đã chọn.

6. **Bước 6 - Chuyển trang:** Khi có nhiều sản phẩm, người dùng có thể nhấn vào các số trang (1, 2, 3...) hoặc nút "Trang sau" để xem thêm sản phẩm. Mỗi trang hiển thị 12 sản phẩm.

**Ghi chú chèn ảnh:**

- `result-products-index.png`: Trang danh sách sản phẩm đầy đủ với bộ lọc, thanh sắp xếp và phân trang
- `result-products-filter-applied.png`: Kết quả sau khi áp dụng bộ lọc (ví dụ: Category=Sneakers, Price=500k-1M)
- `result-products-pagination.png`: Thanh phân trang hiển thị trang 2/5 với thông tin "Showing 13-24 of 58 products"
- `result-products-search.png`: Kết quả tìm kiếm theo từ khóa "Nike"

### 4.1.2. Luồng xem chi tiết và thêm sản phẩm vào giỏ

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang chi tiết:** Người dùng nhấp vào một sản phẩm từ danh sách. Trang chi tiết sản phẩm hiển thị với thông tin đầy đủ.

2. **Bước 2 - Xem thông tin sản phẩm:** Màn hình hiển thị:

   - Bên trái: Hình ảnh lớn của sản phẩm, có các ảnh nhỏ bên dưới để xem góc khác nhau
   - Bên phải: Tên sản phẩm, giá cơ bản, mô tả chi tiết, danh mục
   - Phần chọn biến thể với:
     - Các nút chọn màu sắc (ví dụ: Đen, Trắng, Đỏ)
     - Các nút chọn kích cỡ (ví dụ: 39, 40, 41, 42, 43)
     - Hiển thị số lượng còn trong kho
     - Ô nhập số lượng muốn mua với nút +/- để tăng giảm
     - Nút "Thêm vào giỏ hàng"

3. **Bước 3 - Chọn màu sắc:** Người dùng nhấp vào một nút màu. Nút được chọn sẽ được tô đậm hoặc có viền để phân biệt.

4. **Bước 4 - Chọn kích cỡ:** Người dùng nhấp vào một nút kích cỡ. Sau khi chọn:

   - Nút được chọn sẽ được tô đậm
   - Giá của biến thể cụ thể sẽ được hiển thị (nếu khác giá cơ bản)
   - Số lượng còn trong kho của biến thể này được hiển thị (ví dụ: "Còn 15 sản phẩm")
   - Nếu biến thể này hết hàng, hiển thị "Hết hàng" và nút "Thêm vào giỏ" bị vô hiệu hóa

5. **Bước 5 - Chọn số lượng:** Người dùng có thể:

   - Nhấn nút "+" để tăng số lượng
   - Nhấn nút "-" để giảm số lượng
   - Hoặc nhập trực tiếp số lượng vào ô input
   - Số lượng tối đa không vượt quá số lượng tồn kho

6. **Bước 6 - Thêm vào giỏ hàng:** Người dùng nhấn nút "Thêm vào giỏ hàng":
   - Nếu chưa đăng nhập, hệ thống chuyển đến trang đăng nhập
   - Nếu đã đăng nhập, một thông báo nhỏ xuất hiện góc phải màn hình: "Đã thêm sản phẩm vào giỏ hàng"
   - Biểu tượng giỏ hàng trên thanh menu cập nhật số lượng sản phẩm (ví dụ: hiển thị số "3" bên cạnh icon giỏ)

**Ghi chú chèn ảnh:**

- `result-product-details.png`: Trang chi tiết sản phẩm đầy đủ với image gallery, thông tin và danh sách biến thể
- `result-product-variant-selection.png`: Trạng thái đã chọn Color=Red, Size=42, hiển thị giá và tồn kho cụ thể
- `result-product-out-of-stock.png`: Variant hết hàng với message "Hết hàng" và nút "Thêm vào giỏ" bị vô hiệu
- `result-product-add-to-cart-success.png`: Toast notification "Đã thêm sản phẩm vào giỏ hàng" xuất hiện góc phải màn hình

### 4.1.3. Luồng quản lý giỏ hàng

**Mô tả luồng:**

1. **Bước 1 - Truy cập giỏ hàng:** Người dùng nhấp vào biểu tượng giỏ hàng trên thanh menu. Nếu chưa đăng nhập, hệ thống sẽ yêu cầu đăng nhập trước.

2. **Bước 2 - Xem giỏ hàng:** Trang giỏ hàng hiển thị:

   - Bảng danh sách sản phẩm trong giỏ với các cột:
     - Hình ảnh sản phẩm
     - Tên sản phẩm (kèm thông tin: Kích cỡ: 42, Màu: Đỏ)
     - Đơn giá
     - Số lượng (có ô input với nút +/- để thay đổi)
     - Thành tiền (đơn giá × số lượng)
     - Nút "Xóa" để xóa sản phẩm khỏi giỏ
   - Ở bên phải: Bảng tóm tắt đơn hàng (Order Summary) hiển thị:
     - Tổng tạm tính (Subtotal)
     - Phí vận chuyển (miễn phí)
     - Tổng cộng (Total)
     - Nút "Tiến hành thanh toán"
   - Nếu giỏ hàng trống: hiển thị thông báo "Giỏ hàng của bạn đang trống" với nút "Tiếp tục mua sắm"

3. **Bước 3 - Thay đổi số lượng:** Người dùng có thể:

   - Nhấn nút "+" để tăng số lượng của một sản phẩm
   - Nhấn nút "-" để giảm số lượng
   - Hoặc nhập trực tiếp số lượng vào ô

   Khi thay đổi số lượng:

   - Hệ thống kiểm tra số lượng có hợp lệ không (phải lớn hơn 0 và không vượt quá tồn kho)
   - Nếu vượt quá tồn kho, hiển thị thông báo lỗi: "Số lượng vượt quá tồn kho hiện có"
   - Nếu hợp lệ, thành tiền của sản phẩm và tổng tiền giỏ hàng được cập nhật tự động

4. **Bước 4 - Xóa sản phẩm:** Người dùng nhấn nút "Xóa" bên cạnh một sản phẩm:

   - Một hộp thoại xác nhận xuất hiện: "Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?"
   - Nếu người dùng xác nhận, sản phẩm sẽ biến mất khỏi danh sách và tổng tiền được cập nhật
   - Nếu sau khi xóa mà giỏ hàng trống, hiển thị thông báo "Giỏ hàng trống"

5. **Bước 5 - Tiến hành thanh toán:** Người dùng nhấn nút "Tiến hành thanh toán" ở bảng tóm tắt, hệ thống chuyển đến trang nhập thông tin giao hàng.

**Ghi chú chèn ảnh:**

- `result-cart-with-items.png`: Giỏ hàng có 3 sản phẩm với đầy đủ thông tin và Order Summary
- `result-cart-update-quantity-ajax.png`: Đang cập nhật số lượng, sau đó thành tiền và tổng tiền được cập nhật
- `result-cart-update-error.png`: Thông báo lỗi "Số lượng vượt quá tồn kho hiện có"
- `result-cart-remove-confirm.png`: Dialog xác nhận "Bạn có chắc muốn xóa sản phẩm này?"
- `result-cart-empty.png`: Giỏ hàng rỗng với icon và nút "Tiếp tục mua sắm"

### 4.1.4. Luồng đặt hàng (Checkout)

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang thanh toán:** Từ giỏ hàng, người dùng nhấn nút "Tiến hành thanh toán". Trang thanh toán hiển thị.

2. **Bước 2 - Xem form nhập thông tin:** Màn hình hiển thị:

   - Bên trái: Form nhập thông tin giao hàng gồm các trường:
     - Họ và tên\* (bắt buộc)
     - Số điện thoại\* (bắt buộc)
     - Email
     - Địa chỉ giao hàng\* (bắt buộc)
     - Ghi chú (không bắt buộc)
   - Bên phải: Tóm tắt đơn hàng (Order Summary) hiển thị danh sách sản phẩm và tổng tiền
   - Nút "Đặt hàng" ở cuối form
   - Các trường bắt buộc có dấu \* màu đỏ
   - Form có thể được điền sẵn với thông tin người dùng đã lưu trước đó

3. **Bước 3 - Điền thông tin giao hàng:** Người dùng điền các thông tin cần thiết vào form. Nếu bỏ trống các trường bắt buộc, sẽ có thông báo lỗi hiển thị bên dưới trường đó (ví dụ: "Vui lòng nhập họ tên", "Số điện thoại không hợp lệ").

4. **Bước 4 - Xác nhận đặt hàng:** Sau khi điền đầy đủ thông tin, người dùng nhấn nút "Đặt hàng":

   - Nếu có lỗi trong form (thiếu thông tin, định dạng sai), các thông báo lỗi sẽ hiển thị và yêu cầu sửa lại
   - Nếu thông tin hợp lệ, nút "Đặt hàng" sẽ chuyển sang trạng thái "Đang xử lý..." với biểu tượng loading

5. **Bước 5 - Xử lý đơn hàng:** Hệ thống thực hiện:

   - Tạo đơn hàng mới với mã đơn hàng tự động (ví dụ: ORD20231208145030)
   - Chuyển thông tin sản phẩm từ giỏ hàng sang đơn hàng
   - Trừ số lượng tồn kho của các sản phẩm đã đặt
   - Nếu có sản phẩm nào hết hàng trong lúc xử lý, hiển thị thông báo lỗi: "Sản phẩm X không đủ hàng"
   - Xóa sạch giỏ hàng sau khi đặt hàng thành công

6. **Bước 6 - Chuyển đến trang xác nhận:** Nếu đặt hàng thành công, trang tự động chuyển sang trang xác nhận đơn hàng.

**Ghi chú chèn ảnh:**

- `result-checkout-form.png`: Trang checkout với form thông tin giao hàng và Order Summary
- `result-checkout-validation-errors.png`: Form hiển thị các lỗi validation cho trường bắt buộc
- `result-checkout-processing.png`: Trạng thái đang xử lý với nút "Đang xử lý..." và icon loading
- `result-checkout-insufficient-stock-error.png`: Thông báo lỗi "Sản phẩm X không đủ hàng trong kho"

### 4.1.5. Luồng xác nhận và xem lịch sử đơn hàng

**Luồng xác nhận đơn hàng:**

1. **Bước 1 - Hiển thị trang xác nhận:** Sau khi đặt hàng thành công, người dùng được chuyển tự động đến trang xác nhận.

2. **Bước 2 - Xem thông tin đơn hàng:** Trang xác nhận hiển thị:
   - Biểu tượng thành công (dấu tích xanh) với thông báo "Đặt hàng thành công!"
   - Thông tin đơn hàng:
     - Mã đơn hàng (ví dụ: ORD20231208145030)
     - Ngày đặt hàng
     - Trạng thái: Chờ xác nhận
     - Tổng tiền
   - Bảng danh sách sản phẩm đã đặt với: Tên, Số lượng, Đơn giá, Thành tiền
   - Thông tin giao hàng: Địa chỉ và số điện thoại
   - Hai nút: "Xem đơn hàng của tôi" và "Tiếp tục mua sắm"

**Ghi chú chèn ảnh:**

- `result-order-confirmation.png`: Trang xác nhận đơn hàng thành công với đầy đủ thông tin

**Luồng xem lịch sử đơn hàng:**

1. **Bước 1 - Truy cập trang đơn hàng:** Người dùng nhấp vào "Đơn hàng của tôi" trong menu tài khoản hoặc từ trang xác nhận.

2. **Bước 2 - Xem danh sách đơn hàng:** Trang hiển thị bảng danh sách tất cả đơn hàng của người dùng với các cột:

   - Mã đơn hàng
   - Ngày đặt
   - Trạng thái (được hiển thị bằng nhãn màu: Chờ xác nhận - vàng, Đã xác nhận - xanh dương, Đang giao - cam, Đã giao - xanh lá, Đã hủy - đỏ)
   - Tổng tiền
   - Nút "Xem chi tiết"

   Các đơn hàng được sắp xếp theo thứ tự mới nhất trước. Nếu chưa có đơn hàng nào, hiển thị: "Bạn chưa có đơn hàng nào"

3. **Bước 3 - Xem chi tiết đơn hàng:** Người dùng nhấn nút "Xem chi tiết" của một đơn hàng:
   - Trang chi tiết hoặc popup hiển thị:
     - Thông tin đơn hàng đầy đủ
     - Danh sách sản phẩm trong đơn
     - Thông tin giao hàng
     - Dòng thời gian trạng thái đơn hàng (nếu có)

**Ghi chú chèn ảnh:**

- `result-my-orders-list.png`: Danh sách đơn hàng với 5 đơn ở các trạng thái khác nhau
- `result-my-orders-empty.png`: Trạng thái chưa có đơn hàng nào với thông báo và nút mua sắm
- `result-order-details.png`: Chi tiết một đơn hàng với danh sách sản phẩm và thông tin giao hàng

## 4.2. Luồng chức năng quản trị (Admin/Staff)

### 4.2.1. Luồng quản lý sản phẩm (CRUD Products)

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang quản lý:** Admin hoặc nhân viên đăng nhập với tài khoản có quyền quản trị, sau đó truy cập vào trang quản lý sản phẩm.

2. **Bước 2 - Xem danh sách sản phẩm:** Trang hiển thị bảng danh sách tất cả sản phẩm với các cột:
   - Mã sản phẩm
   - Hình ảnh
   - Tên sản phẩm
   - Danh mục
   - Giá cơ bản
   - Số lượng biến thể
   - Trạng thái (Hoạt động/Ẩn)
   - Hành động: Nút "Xem", "Sửa", "Xóa"

**Luồng thêm sản phẩm mới:**

3. **Bước 3 - Mở form thêm sản phẩm:** Admin nhấn nút "Thêm sản phẩm mới" trên đầu trang, một cửa sổ popup (modal) xuất hiện với form nhập liệu:

   - Tên sản phẩm\* (bắt buộc)
   - Mô tả (textarea)
   - Danh mục\* (dropdown chọn danh mục, bắt buộc)
   - Giá cơ bản\* (nhập số, tối thiểu 0, bắt buộc)
   - URL hình ảnh
   - Trạng thái hoạt động (checkbox, mặc định được chọn)

4. **Bước 4 - Điền thông tin và lưu:** Admin điền các thông tin vào form:
   - Nếu thiếu thông tin bắt buộc hoặc sai định dạng, các thông báo lỗi sẽ hiển thị
   - Khi thông tin hợp lệ, admin nhấn nút "Lưu"
   - Popup đóng lại, trang làm mới và hiển thị thông báo "Thêm sản phẩm thành công!"
   - Sản phẩm mới xuất hiện trong bảng danh sách

**Luồng sửa sản phẩm:**

5. **Bước 5 - Mở form sửa:** Admin nhấn nút "Sửa" bên cạnh một sản phẩm:

   - Popup xuất hiện với form đã được điền sẵn thông tin hiện tại của sản phẩm
   - Admin có thể thay đổi bất kỳ thông tin nào

6. **Bước 6 - Lưu thay đổi:** Sau khi chỉnh sửa, admin nhấn "Cập nhật":
   - Nếu thông tin hợp lệ, thay đổi được lưu
   - Popup đóng, hiển thị thông báo "Cập nhật sản phẩm thành công!"
   - Thông tin trong bảng được cập nhật tự động

**Luồng xóa sản phẩm:**

7. **Bước 7 - Xác nhận xóa:** Admin nhấn nút "Xóa" bên cạnh một sản phẩm:

   - Hộp thoại xác nhận xuất hiện: "Bạn có chắc chắn muốn xóa sản phẩm này?"

8. **Bước 8 - Thực hiện xóa:**
   - Nếu admin xác nhận:
     - Hệ thống kiểm tra xem sản phẩm có trong đơn hàng nào không
     - Nếu có đơn hàng chứa sản phẩm này, hiển thị lỗi: "Không thể xóa sản phẩm đã có trong đơn hàng"
     - Nếu không có, sản phẩm sẽ bị xóa khỏi danh sách
     - Hiển thị thông báo "Xóa sản phẩm thành công!"

**Ghi chú chèn ảnh:**

- `result-staff-products-list.png`: Bảng danh sách sản phẩm với đầy đủ thông tin và nút hành động
- `result-staff-product-create-modal.png`: Popup form thêm sản phẩm mới
- `result-staff-product-edit-modal.png`: Popup form sửa sản phẩm với dữ liệu đã điền sẵn
- `result-staff-product-delete-confirm.png`: Hộp thoại xác nhận xóa
- `result-staff-product-delete-error.png`: Thông báo lỗi "Không thể xóa sản phẩm đã có trong đơn hàng"
- `result-staff-product-success.png`: Toast thông báo "Cập nhật sản phẩm thành công"

### 4.2.2. Luồng quản lý biến thể sản phẩm (CRUD Product Variants)

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang quản lý:** Admin truy cập vào trang quản lý biến thể sản phẩm.

2. **Bước 2 - Xem danh sách biến thể:** Trang hiển thị bảng danh sách tất cả biến thể với các cột:
   - Mã biến thể
   - Tên sản phẩm
   - Kích cỡ
   - Màu sắc
   - Giá
   - Số lượng tồn kho
   - Trạng thái (Có sẵn/Hết hàng)
   - Hành động: Nút "Sửa", "Xóa"

**Luồng thêm biến thể mới:**

3. **Bước 3 - Mở form thêm:** Admin nhấn nút "Thêm biến thể", popup hiển thị form với các trường:

   - Sản phẩm\* (dropdown chọn sản phẩm, bắt buộc)
   - Kích cỡ\* (dropdown chọn size, bắt buộc)
   - Màu sắc\* (dropdown chọn màu, bắt buộc)
   - Giá\* (nhập số, bắt buộc)
   - Số lượng tồn kho\* (nhập số, tối thiểu 0, bắt buộc)
   - Có sẵn (checkbox)

4. **Bước 4 - Lưu biến thể:** Admin điền thông tin và nhấn "Lưu":
   - Hệ thống kiểm tra xem biến thể này đã tồn tại chưa (cùng sản phẩm, size, màu)
   - Nếu đã tồn tại, hiển thị lỗi: "Biến thể này đã tồn tại cho sản phẩm này"
   - Nếu chưa tồn tại, lưu biến thể mới và hiển thị thông báo "Thêm biến thể thành công!"

**Luồng sửa và xóa biến thể:**

5. **Bước 5 - Sửa biến thể:** Admin nhấn "Sửa", popup hiển thị form đã điền sẵn thông tin. Admin có thể thay đổi giá và số lượng tồn kho, sau đó lưu lại.

6. **Bước 6 - Xóa biến thể:** Admin nhấn "Xóa":
   - Hộp thoại xác nhận xuất hiện
   - Nếu biến thể đang có trong giỏ hàng hoặc đơn hàng, hiển thị lỗi: "Không thể xóa biến thể đang được sử dụng"
   - Nếu có thể xóa, biến thể sẽ bị xóa khỏi danh sách

**Ghi chú chèn ảnh:**

- `result-staff-variants-list.png`: Danh sách biến thể với tên sản phẩm, size, màu, tồn kho
- `result-staff-variant-create-modal.png`: Form thêm biến thể mới
- `result-staff-variant-duplicate-error.png`: Thông báo lỗi "Biến thể này đã tồn tại"

### 4.2.3. Luồng quản lý đơn hàng (Staff/Orders)

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang quản lý:** Admin truy cập vào trang quản lý đơn hàng.

2. **Bước 2 - Xem danh sách đơn hàng:** Trang hiển thị bảng danh sách tất cả đơn hàng với các cột:

   - Mã đơn hàng
   - Tên khách hàng
   - Ngày đặt hàng
   - Trạng thái (nhãn màu: Chờ xác nhận, Đã xác nhận, Đang giao, Đã giao, Đã hủy)
   - Tổng tiền
   - Hành động: Nút "Xem chi tiết", "Cập nhật trạng thái"

   Danh sách được sắp xếp theo thứ tự mới nhất trước.

3. **Bước 3 - Xem chi tiết đơn hàng:** Admin nhấn nút "Xem chi tiết" của một đơn hàng:

   - Popup hoặc trang mới hiển thị:
     - Thông tin khách hàng (Tên, Số điện thoại, Địa chỉ giao hàng)
     - Bảng danh sách sản phẩm trong đơn với: Tên, Size, Màu, Số lượng, Đơn giá, Thành tiền
     - Trạng thái hiện tại của đơn hàng
     - Dòng thời gian các trạng thái (nếu có)
     - Dropdown chọn trạng thái mới
     - Nút "Cập nhật trạng thái"

4. **Bước 4 - Cập nhật trạng thái đơn hàng:** Admin chọn trạng thái mới từ dropdown:

   - Các trạng thái theo thứ tự: Chờ xác nhận → Đã xác nhận → Đang giao → Đã giao
   - Hoặc từ Chờ xác nhận/Đã xác nhận có thể chuyển sang Đã hủy
   - Hệ thống không cho phép chuyển trạng thái không hợp lý (ví dụ: từ Chờ xác nhận thẳng sang Đã giao)

5. **Bước 5 - Lưu thay đổi trạng thái:** Admin nhấn "Cập nhật trạng thái":
   - Trạng thái đơn hàng được cập nhật
   - Hiển thị thông báo "Cập nhật trạng thái đơn hàng thành công"
   - Trạng thái mới hiển thị trong bảng danh sách đơn hàng

**Ghi chú chèn ảnh:**

- `result-staff-orders-list.png`: Danh sách đơn hàng với các trạng thái khác nhau
- `result-staff-order-details-modal.png`: Popup chi tiết đơn hàng với thông tin khách hàng và sản phẩm
- `result-staff-order-update-status.png`: Dropdown chọn trạng thái mới và nút Cập nhật
- `result-staff-order-status-updated.png`: Thông báo "Cập nhật trạng thái thành công"

### 4.2.4. Luồng quản lý khách hàng (Staff/Customers)

**Mô tả luồng:**

1. **Bước 1 - Truy cập trang quản lý:** Admin truy cập vào trang quản lý khách hàng.

2. **Bước 2 - Xem danh sách khách hàng:** Trang hiển thị bảng danh sách tất cả khách hàng với các cột:

   - Mã khách hàng
   - Email
   - Họ và tên
   - Số điện thoại
   - Ngày đăng ký
   - Tổng số đơn hàng
   - Hành động: Nút "Xem chi tiết", "Sửa"

3. **Bước 3 - Xem chi tiết khách hàng:** Admin nhấn nút "Xem chi tiết":

   - Popup hoặc trang mới hiển thị:
     - Thông tin cá nhân của khách hàng
     - Lịch sử đơn hàng của khách hàng này
     - Tổng số tiền đã chi tiêu
     - Ngày đặt hàng gần nhất

4. **Bước 4 - Sửa thông tin khách hàng (nếu có):** Admin nhấn nút "Sửa":
   - Form hiển thị với các trường có thể chỉnh sửa:
     - Họ và tên
     - Số điện thoại
     - Địa chỉ
   - Email không thể sửa (dùng làm tên đăng nhập)
   - Mật khẩu không hiển thị và không thể sửa từ trang này
   - Admin lưu lại thay đổi

**Ghi chú chèn ảnh:**

- `result-staff-customers-list.png`: Danh sách khách hàng với thông tin cơ bản
- `result-staff-customer-details.png`: Chi tiết thông tin khách hàng và lịch sử đơn hàng

### 4.2.5. Luồng Dashboard và thống kê

**Mô tả luồng:**

1. **Bước 1 - Truy cập Dashboard:** Admin đăng nhập và vào trang Dashboard (trang chủ của khu vực quản trị).

2. **Bước 2 - Xem các chỉ số tổng quan:** Phía trên trang hiển thị 4 thẻ thống kê chính:

   - Tổng số sản phẩm (với icon và màu xanh dương)
   - Tổng số đơn hàng (với icon và màu xanh lá)
   - Tổng doanh thu (với icon và màu vàng)
   - Tổng số khách hàng (với icon và màu cam)

   Mỗi thẻ hiển thị con số lớn và tiêu đề.

3. **Bước 3 - Xem đơn hàng gần đây:** Bên dưới các thẻ thống kê, có bảng "Đơn hàng gần đây" hiển thị 10 đơn hàng mới nhất với:

   - Mã đơn hàng
   - Khách hàng
   - Ngày đặt
   - Trạng thái
   - Tổng tiền
   - Link "Xem chi tiết"

4. **Bước 4 - Xem sản phẩm bán chạy:** Có thể có thêm bảng hoặc biểu đồ hiển thị:

   - Top 5 sản phẩm bán chạy nhất với số lượng đã bán
   - Hoặc biểu đồ phân bố đơn hàng theo trạng thái (biểu đồ tròn)

5. **Bước 5 - Điều hướng nhanh:** Từ Dashboard, admin có thể nhấn vào các số liệu hoặc link để chuyển nhanh đến trang quản lý tương ứng (sản phẩm, đơn hàng, khách hàng).

**Ghi chú chèn ảnh:**

- `result-staff-dashboard.png`: Dashboard với 4 thẻ KPI, bảng đơn hàng gần đây và biểu đồ
- `result-staff-dashboard-top-products.png`: Bảng top 5 sản phẩm bán chạy nhất

## 4.3. Đánh giá kết quả

Hệ thống ShoesShopWeb đã hiện thực thành công toàn bộ các luồng chức năng theo yêu cầu đề ra. Từ góc nhìn người dùng, các chức năng hoạt động mượt mà và trực quan:

- **Luồng người dùng:** Khách hàng có thể dễ dàng duyệt và tìm kiếm sản phẩm với bộ lọc đa dạng, xem chi tiết sản phẩm với hình ảnh và thông tin đầy đủ, thêm sản phẩm vào giỏ hàng nhanh chóng, quản lý giỏ hàng với khả năng cập nhật số lượng và xóa sản phẩm, đặt hàng với form nhập thông tin rõ ràng, và theo dõi lịch sử đơn hàng một cách dễ dàng.

- **Luồng quản trị:** Quản trị viên có đầy đủ công cụ để quản lý sản phẩm (thêm, sửa, xóa) với kiểm tra ràng buộc dữ liệu, quản lý biến thể sản phẩm chi tiết theo size và màu sắc, theo dõi và cập nhật trạng thái đơn hàng, xem thông tin khách hàng, và có dashboard tổng quan với các chỉ số quan trọng.

- **Trải nghiệm người dùng:** Giao diện responsive, thông báo rõ ràng khi thao tác thành công hoặc có lỗi, các form có validation đầy đủ, và các thao tác cập nhật diễn ra nhanh chóng nhờ sử dụng AJAX.

Hệ thống đảm bảo tính toàn vẹn dữ liệu thông qua các kiểm tra nghiệp vụ (kiểm tra tồn kho khi đặt hàng, kiểm tra ràng buộc khi xóa sản phẩm) và cung cấp trải nghiệm mượt mà cho cả khách hàng và quản trị viên. Hệ thống sẵn sàng cho việc mở rộng thêm các tính năng như thanh toán trực tuyến, gửi email thông báo, và các báo cáo thống kê nâng cao.

# CHƯƠNG 5: KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN

Kết luận: Đồ án đã hiện thực một website bán giày trực tuyến theo kiến trúc N-Layer, vận dụng ASP.NET Core 9.0 và EF Core 9.0, dùng PostgreSQL 16 qua Docker Compose. Các chức năng cốt lõi được hoàn thiện và chạy ổn định trong môi trường phát triển.

Hướng phát triển:

- Tích hợp cổng thanh toán (VNPay/MoMo/Stripe), email xác thực và thông báo đơn hàng.
- Bổ sung báo cáo thống kê nâng cao, phân tích doanh thu theo thời gian.
- Áp dụng bộ lọc nâng cao, gợi ý sản phẩm, wishlist.
- Triển khai CI/CD và đóng gói container cho toàn bộ ứng dụng.

# DANH MỤC TÀI LIỆU THAM KHẢO

- Microsoft Docs – ASP.NET Core: https://learn.microsoft.com/aspnet/core
- Microsoft Docs – EF Core: https://learn.microsoft.com/ef/core
- PostgreSQL Official Documentation: https://www.postgresql.org/docs/
- Docker Documentation: https://docs.docker.com/
- README của dự án: `README.md` trong repository ShoesShopWeb (tham chiếu cấu trúc, tính năng và hướng dẫn chạy).
