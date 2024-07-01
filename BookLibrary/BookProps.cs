namespace BookLibrary
{
    public class BookProps
    {
        // Kitab sinfinə veriləcək xüsusiyyətlərdir
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookPage { get; set; }
        public double BookPrice { get; set; }
        public string BookGenre { get; set; }

        // Mətnə çevirmək üçün
        public override string ToString()
        {
            return $"Ad: {BookName}, Müəllif: {BookAuthor}, Səhifə sayı: {BookPage}, Qiymət: {BookPrice} AZN, Janr: {BookGenre} \n";
        }
    }
}
