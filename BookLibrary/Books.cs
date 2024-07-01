using System.Diagnostics;

namespace BookLibrary
{
    public class Books
    {
        // Kitabxana adı
        public string LibraryName { get; set; }

        // Kitab siyahısı - MASSİV
        private BookProps[] _bookList;

        // Kirayə kitab siyahısı - LİST
        private List<BookProps> _rentBookList;

        // Kitabxana adı üçün alınan parametrlər - kitabxana adı və kitab sayı
        public Books(string bookLibraryName, int bookCount = 1)
        {
            // Kitabxana adını mənimsətmək üçün
            LibraryName = bookLibraryName;

            // Kitab siyahısı üçün
            _bookList = new BookProps[bookCount];

            // Kirayədəki kitab siyahısı üçün
            _rentBookList = new List<BookProps>();
        }

        // Ümumi kitab siyahısını göstərir
        public void BookList()
        {
            int say = 1;
            // Kitab siyahısına baxır əgər kitab mövcud deyilsə, digər kitaba keçir
            foreach (var book in _bookList)
            {
                if (book is null)
                    continue;

                // Kitab əlavə olunanda yazılır
                Console.WriteLine($"{say}. Kitab adı: {book.BookName}, Yazıçı: {book.BookAuthor}, Səhifə sayı: {book.BookPage}, Qiymət: {book.BookPrice} AZN, Janr: {book.BookGenre} \n \n");
                say++;
            }
        }

        // Yeni kitab əlavə edir
        public bool BookAdd(BookProps book)
        {
            // Kitab siyahısının uzunluğu qədərdir
            for (int i = 0; i < _bookList.Length; i++)
            {
                // Əgər indeks - i boşdursa, əlavə olunan kitab bu indeksə əlavə olunur
                if (_bookList[i] == null)
                {
                    _bookList[i] = book;
                    return true;
                }
            }
            // Əgər kitab siyahısında yer yoxdursa, yeni sıra yaradır və əlavə olunan kitabı bura əlavə edir
            Array.Resize(ref _bookList, _bookList.Length + 1);
            _bookList[_bookList.Length - 1] = book;
            return true;
        }

        // Kitab kirayə götürür
        public void BookRentList()
        {
            Console.WriteLine("Kirayə götürmək istədiyiniz kitabın adını daxil edin: ");
            string rentBookName = Console.ReadLine();
            bool bookFound = false;

            // Kitab siyahısının uzunluğu qədərdir
            for (int i = 0; i < _bookList.Length; i++)
            {
                // Əgər indeks boş deyilsə və bu indeksdə kitab adı varsa onu axtarır və kirayə verir
                if (!(_bookList[i] == null) && _bookList[i].BookName.Equals(rentBookName, StringComparison.OrdinalIgnoreCase))
                {
                    _rentBookList.Add(_bookList[i]);
                    _bookList[i] = null;
                    BookMenu("Kİtab kirayə götürüldü.", ConsoleColor.Green);
                    ListRentedBooks();
                    bookFound = true;
                    break;
                }
            }

            // Əgər kitab yoxdursa və ya adı yanlış daxil edilərsə bu yazı çıxır
            if (!bookFound)
                BookMenu("Kitab tapılmadı", ConsoleColor.Red);
        }

        // Kirayədə olan kitabların siyahısını göstərir
        public void ListRentedBooks()
        {
            // Kirayə kitabların siyahısı ilk olaraq 0-dır
            if (_rentBookList.Count == 0)
            {
                Console.WriteLine("Hazırda kirayədə kitab yoxdur");
                return;
            }
            // Kitab kirayəyə verilərsə, kirayə siyahısında axtarılır və siyahıya əlavə olunur
            Console.WriteLine("Kirayədə olan kitabların siyahısı");
            int rentBookCount = 1;
            foreach (var rentBookItem in _rentBookList)
            {
                Console.WriteLine($"{rentBookCount}. Kitab adı: {rentBookItem.BookName}, Yazıçı: {rentBookItem.BookAuthor}, Səhifə sayı: {rentBookItem.BookPage}, Qiyməti: {rentBookItem.BookPrice} AZN, Janrı: {rentBookItem.BookGenre}\n \n");
                rentBookCount++;
            }
        }

        // Kitab siyahısında axtarış edir
        public void BookSearch(string kitabAdi = "", string kitabMuellifi = "", int kitabSehifeSayi = 0, double kitabQiymeti = 0.0, string kitabJanri = "")
        {
            bool searchBook = false;
            // Kitab siyahısında dövr edir
            foreach (var kitab in _bookList)
            {
                // Əgər kitab mövcud deyilsə davam edir
                if (kitab is null)
                    continue;


                // Axtarışda kitabın hər detalı düzgün olmalıdır
                if (kitab.BookName == kitabAdi && kitab.BookAuthor == kitabMuellifi && kitab.BookPage == kitabSehifeSayi && kitab.BookPrice == kitabQiymeti && kitab.BookGenre == kitabJanri)
                {
                    // Əgər bütün şərtləri ödəyirsə axtarış true çıxır və konsolda axtarılan kitab yazılır
                    searchBook = true;
                    Console.WriteLine(kitab);
                }
            }

            // Əgər hər hansı detal yanlış olarsa bu yazı çıxır
            if (!searchBook)
                Console.WriteLine("Kitab mövcud deyil.");
        }

        // Kod təkrarının qarşısını almaq üçün
        void BookMenu(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}