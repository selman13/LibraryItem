using System.Diagnostics;

namespace BookLibrary
{
    public class Journals
    {
        // Kitabxana adı
        public string LibraryName { get; set; }

        // Jurnal siyahısı - MASSİV
        private JournalProps[] _journalList;
        
        // Kirayə kitab siyahısı - LİST
        private List<JournalProps> _rentJournalList;
        // Kitabxana adı üçün alınan parametrlər - kitabxana adı və jurnal sayı
        public Journals(string journalLibraryName, int journalCount = 1)
        {
            // Kitabxana adını mənimsətmək üçün
            LibraryName = journalLibraryName;

            // Jurnal siyahısı üçün
            _journalList = new JournalProps[journalCount];

            // Kirayədəki jurnal siyahısı üçün
            _rentJournalList = new List<JournalProps>();
        }

        // Ümumi jurnal siyahısını göstərir
        public void JournalList()
        {
            int say = 1;
            // Jurnal siyahısına baxır əgər jurnal mövcud deyilsə, digər jurnala keçir
            foreach (var journal in _journalList)
            {
                if (journal is null)
                    continue;
                
                // Jurnal əlavə olunanda yazılır
                Console.WriteLine($"{say}. Jurnal adı: {journal.JournalName}, Səhifə sayı: {journal.JournalPage}, Qiymət: {journal.JournalPrice} AZN, Nömrə sayı: {journal.JournalIssueNumber} \n \n");
                say++;
            }
        }

        // Yeni jurnal əlavə edir
        public bool JournalAdd(JournalProps journal)
        {
            // Jurnal siyahısının uzunluğu qədərdir
            for (int i = 0; i < _journalList.Length; i++)
            {
                // Əgər indeks - i boşdursa, əlavə olunan jurnal bu indeksə əlavə olunur
                if (_journalList[i] == null)
                {
                    _journalList[i] = journal;
                    return true;
                }
            }
            // Əgər jurnal siyahısında yer yoxdursa, yeni sıra yaradır və əlavə olunan jurnalı bura əlavə edir
            Array.Resize(ref _journalList, _journalList.Length + 1);
            _journalList[_journalList.Length - 1] = journal;
            return true;
        }

        // Jurnal kirayə götürür
        public void JournalRentList()
        {
            Console.WriteLine("Kirayə götürmək istədiyiniz jurnalın adını daxil edin: ");
            string rentJournalName = Console.ReadLine();
            bool JournalFound = false;

            // Jurnal siyahısının uzunluğu qədərdir
            for (int i = 0; i < _journalList.Length; i++)
            {
                // Əgər indeks boş deyilsə və bu indeksdə jurnal adı varsa onu axtarır və kirayə verir
                if (!(_journalList[i] == null) && _journalList[i].JournalName.Equals(rentJournalName, StringComparison.OrdinalIgnoreCase))
                {
                    _rentJournalList.Add(_journalList[i]);
                    _journalList[i] = null;
                    JournalMenu("Jurnal kirayə götürüldü.", ConsoleColor.Green);
                    ListRentedJournals();
                    JournalFound = true;
                    break;
                }
            }

            // Əgər jurnal yoxdursa və ya adı yanlış daxil edilərsə bu yazı çıxır
            if (!JournalFound)
                JournalMenu("Jurnal tapılmadı", ConsoleColor.Red);
        }

        // Kirayədə olan jurnalların siyahısını göstərir
        public void ListRentedJournals()
        {
            // Kirayə jurnalların siyahısı ilk olaraq 0-dır
            if (_rentJournalList.Count == 0)
            {
                Console.WriteLine("Hazırda kirayədə jurnal yoxdur");
                return;
            }
            // Jurnal kirayəyə verilərsə, kirayə siyahısında axtarılır və siyahıya əlavə olunur
            Console.WriteLine("Kirayədə olan kitabların siyahısı");
            int rentJournalCount = 1;
            foreach (var rentJournalItem in _rentJournalList)
            {
                Console.WriteLine($"{rentJournalCount}. Jurnal adı: {rentJournalItem.JournalName}, Səhifə sayı: {rentJournalItem.JournalPage}, Qiyməti: {rentJournalItem.JournalPrice} AZN, Nömrə sayı:{rentJournalItem.JournalIssueNumber}");
                rentJournalCount++;
            }
        }

        // Jurnal siyahısında axtarış edir
        public void JournalSearch(string jurnalAdi = "", int jurnalSehifeSayi = 0, double jurnalQiymeti = 0.0, int jurnalNomreSayi = 0)
        {
            bool searchJournal = false;
            // Jurnal siyahısında dövr edir
            foreach (var jurnal in _journalList)
            {
                // Əgər jurnal mövcud deyilsə davam edir
                if (jurnal is null)
                    continue;
                

                // Axtarışda jurnalın hər detalı düzgün olmalıdır
                if (jurnal.JournalName == jurnalAdi && jurnal.JournalPage == jurnalSehifeSayi && jurnal.JournalPrice == jurnalQiymeti && jurnal.JournalIssueNumber == jurnalNomreSayi)
                {
                    // Əgər bütün şərtləri ödəyirsə axtarış true çıxır və konsolda axtarılan jurnal yazılır
                    searchJournal = true;
                    Console.WriteLine(jurnal);
                }
            }

            // Əgər hər hansı detal yanlış olarsa bu yazı çıxır
            if (!searchJournal)
               Console.WriteLine("Jurnal mövcud deyil.");
        }
        // Kod təkrarının qarşısını almaq üçün
        void JournalMenu(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}