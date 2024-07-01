using BookLibrary;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// İlk olaraq Login üçün ad və şifrə təyin edirik
Login login = new("Selman", "selman13");

int cehd = 0;
bool loggedIn = false;

while (cehd < 3 && !loggedIn)
{
    PrintMessage("Sistemə daxil olmaq üçün istifadəçi adı və şifrəni daxil edin: ", ConsoleColor.White);
    Console.Write("İstifadəçi adı: ");
    string enteredName = Console.ReadLine();
    Console.Write("İstifadəçi şifrəsi: ");
    string enteredPassword = Console.ReadLine();
    Console.ResetColor();

    if (enteredName == login.Name && enteredPassword == login.Password)
    {
        PrintMessage("Təbriklər! Sistemə daxil oldunuz.", ConsoleColor.Green);
        loggedIn = true;

        var library1 = new Books("Sfera", 35);
        var library2 = new Journals("Sfera", 35);

        // Şərt hər dəfə ödənildikdə bu menyu gəlməlidir
        bool exitMainMenu = false;
        while (!exitMainMenu)
        {
            PrintMessage($"{library1.LibraryName} kitab evinə xoş gəlmisiniz! Aşağıdan istədiyiniz əməliyyatı seçin:", ConsoleColor.White);

            DisplayMenu("1. Kitab\n2. Jurnal\n3. Çıxış", out int mainMenuOperationNumber); 
            switch (mainMenuOperationNumber)
            {
                // KİTAB MENUSU
                case 1:
                    // Alt menyudan çıxana qədər while dövrü davam edir.
                    bool exitBookMenu = false;
                    while (!exitBookMenu)
                    {
                        DisplayMenu("1. Kitab siyahısı\n2. Yeni kitab əlavə etmək\n3. Kitabı kirayə vermək\n4. Kitab axtarmaq\n5. Çıxış", out int bookOperationNumber);

                        switch (bookOperationNumber)
                        {
                            // Kitab siyahısı
                            case 1:
                                library1.BookList();
                                break;

                            // Yeni kitab əlavə etmək
                            case 2:
                                bool addMoreBooks = true;
                                while (addMoreBooks)
                                {
                                    Console.Write("Kitabın adını daxil edin: ");
                                    string bookName = Console.ReadLine();

                                    Console.Write("Yazıçı adını daxil edin: ");
                                    string bookAuthor = Console.ReadLine();

                                    Console.Write("Səhifə sayını daxil edin: ");
                                    int.TryParse(Console.ReadLine(), out int bookPage);

                                    Console.Write("Qiyməti daxil edin: ");
                                    double.TryParse(Console.ReadLine(), out double bookPrice);

                                    Console.Write("Janrını daxil edin: ");
                                    string bookGenre = Console.ReadLine();

                                    // Kitabın əlavə olunması üçün bütün məlumatlar daxil edilməlidir və ən azı 1 səhvdə xəta alınır
                                    if (string.IsNullOrWhiteSpace(bookName) || string.IsNullOrWhiteSpace(bookAuthor) || bookPage <= 0 || bookPrice <= 0 || string.IsNullOrWhiteSpace(bookGenre))
                                    {
                                        PrintMessage("Bütün məlumatları düzgün daxil etməlisiniz!", ConsoleColor.Red);
                                        continue;
                                    }

                                    // Kitab obyekti yaradırıq və dəyərlər təyin edirik
                                    var newBook = new BookProps
                                    {
                                        BookName = bookName,
                                        BookAuthor = bookAuthor,
                                        BookPage = bookPage,
                                        BookPrice = bookPrice,
                                        BookGenre = bookGenre
                                    };

                                    // Əgər kitab obyektində xəta yoxdursa
                                    if (library1.BookAdd(newBook))
                                    {
                                        PrintMessage("Kitab uğurla əlavə edildi.", ConsoleColor.Green);
                                        Console.WriteLine("Yeni kitab əlavə etmək istəyirsiniz? (bəli/xeyr)");
                                        string bookAnswer = Console.ReadLine().Trim().ToLower();

                                        if (bookAnswer == "xeyr")
                                            addMoreBooks = false;
                                    }
                                }
                                break;

                            // Kitab kirayə vermək
                            case 3:
                                library1.BookRentList();
                                break;

                            // Kitab axtarmaq
                            case 4:
                                Console.WriteLine("Axtarmaq üçün kitab məlumatlarını daxil edin: ");
                                Console.Write("Kitab adını daxil edin: ");
                                string BookNameSearch = Console.ReadLine();
                                Console.Write("Kitabın yazıçısını daxil edin: ");
                                string BookAuthorSearch = Console.ReadLine();
                                Console.Write("Kitabın səhifə sayını daxil edin: ");
                                int.TryParse(Console.ReadLine(), out int BookPageSearch);
                                Console.Write("Kitabın qiymətini daxil edin: ");
                                double.TryParse(Console.ReadLine(), out double BookPriceSearch);
                                Console.Write("Kitabın janrını daxil edin: ");
                                string BookGenreSearch = Console.ReadLine();

                                library1.BookSearch(BookNameSearch, BookAuthorSearch, BookPageSearch, BookPriceSearch, BookGenreSearch);
                                break;

                                // Ana menyuya qayıtmaq
                            case 5:
                                PrintMessage("Ana menyuya qayıdılır", ConsoleColor.Yellow);
                                // Alt menyudan çıxılır
                                exitBookMenu = true;
                                break;

                            default:
                                PrintMessage("Xəta! Yanlış seçim daxil edildi", ConsoleColor.Blue);
                                break;
                        }
                    }
                    break;

                    // JURNAL MENUSU
                case 2:
                    // Alt menyudan çıxana qədər while dövrü davam edir.
                    bool exitJournalMenu = false;
                    while (!exitJournalMenu)
                    {
                        DisplayMenu("1. Jurnal siyahısı\n2. Yeni jurnal əlavə etmək\n3. Jurnalı kirayə vermək\n4. Jurnal axtarmaq\n5. Çıxış", out int journalOperationNumber);

                        switch (journalOperationNumber)
                        {
                            // Jurnal siyahısı
                            case 1:
                                library2.JournalList();
                                break;

                            // Yeni jurnal əlavə etmək
                            case 2:
                                bool addMoreJournals = true;
                                while (addMoreJournals)
                                {
                                    Console.Write("Jurnalın adını daxil edin: ");
                                    string journalName = Console.ReadLine();

                                    Console.Write("Səhifə sayını daxil edin: ");
                                    int.TryParse(Console.ReadLine(), out int journalPage);

                                    Console.Write("Qiyməti daxil edin: ");
                                    double.TryParse(Console.ReadLine(), out double journalPrice);

                                    // Jurnalın əlavə olunması üçün bütün məlumatlar daxil edilməlidir və ən azı 1 səhvdə xəta alınır
                                    if (string.IsNullOrWhiteSpace(journalName) || journalPage <= 0 || journalPrice <= 0)
                                    {
                                        PrintMessage("Bütün məlumatları düzgün daxil etməlisiniz!", ConsoleColor.Red);
                                        continue;
                                    }

                                    // Jurnal obyekti yaradırıq və dəyərlər təyin edirik
                                    var newJournal = new JournalProps
                                    {
                                        JournalName = journalName,
                                        JournalPage = journalPage,
                                        JournalPrice = journalPrice
                                    };

                                    // Əgər jurnal obyektində xəta yoxdursa
                                    if (library2.JournalAdd(newJournal))
                                    {
                                        PrintMessage("Jurnal uğurla əlavə edildi.", ConsoleColor.Green);
                                        Console.WriteLine("Yeni jurnal əlavə etmək istəyirsiniz? (bəli/xeyr)");
                                        string journalAnswer = Console.ReadLine().Trim().ToLower();

                                        if (journalAnswer == "xeyr")
                                            addMoreJournals = false;
                                    }
                                }
                                break;

                            // Jurnal kirayə vermək
                            case 3:
                                library2.JournalRentList();
                                break;

                             // Jurnal axtarmaq
                            case 4:
                                Console.WriteLine("Axtarmaq üçün jurnal məlumatlarını daxil edin: ");
                                Console.Write("Jurnal adını daxil edin: ");
                                string JournalNameSearch = Console.ReadLine();
                                Console.Write("Jurnalın səhifə sayını daxil edin: ");
                                int.TryParse(Console.ReadLine(), out int JournalPageSearch);
                                Console.Write("Jurnalın qiymətini daxil edin: ");
                                double.TryParse(Console.ReadLine(), out double JournalPriceSearch);

                                library2.JournalSearch(JournalNameSearch, JournalPageSearch, JournalPriceSearch);
                                break;

                             // Ane menyuya qayıtmaq
                            case 5:
                                PrintMessage("Ana menyuya qayıdılır", ConsoleColor.Yellow);
                                // Alt menyudan çıxılır
                                exitJournalMenu = true;
                                break;

                            default:
                                PrintMessage("Xəta! Yanlış seçim daxil edildi", ConsoleColor.Blue);
                                break;
                        }
                    }
                    break;

                    // SİSTEMDƏN ÇIXIŞ
                case 3:
                    PrintMessage("Sistemdən çıxış edilir", ConsoleColor.Yellow);
                    exitMainMenu = true;
                    break;

                default:
                    PrintMessage("Xəta! Yanlış seçim daxil edildi", ConsoleColor.Blue);
                    break;
            }
        }
    }
    else
    {
        cehd++;
        if (cehd < 3)
            PrintMessage("İstifadəçi adı və ya şifrə yanlışdır. Zəhmət olmasa yenidən cəhd edin.\n", ConsoleColor.Red);
        else
            PrintMessage("3 dəfə səhv cəhd etdiniz. Proqram dayandırılır.", ConsoleColor.DarkRed);
    }
}

// Kod təkrarının qarşısını almaq üçün yazılır
void PrintMessage(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

// Menyu yazılarını qısaltmaq üçün yazılır
void DisplayMenu(string menuOptions, out int operationNumber)
{
    Console.WriteLine(menuOptions);
    Console.Write("Əməliyyata uyğun rəqəmi daxil edin: ");
    int.TryParse(Console.ReadLine(), out operationNumber);
    Console.Clear();
}