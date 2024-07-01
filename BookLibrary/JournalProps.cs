namespace BookLibrary
{
    public class JournalProps
    {
        // Jurnal sinfinə veriləcək xüsusiyyətlərdir
        public string JournalName { get; set; }
        public int JournalPage { get; set; }
        public double JournalPrice { get; set; }

        public int JournalIssueNumber { get; set; }

        // Mətnə çevirmək üçün
        public override string ToString()
        {
            return $"Ad: {JournalName}, Səhifə sayı: {JournalPage}, Qiymət: {JournalPrice} AZN, Nömrə sayı: {JournalIssueNumber} \n";
        }
    }
}
