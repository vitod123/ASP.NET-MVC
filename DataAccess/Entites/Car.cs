using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entites
{
    public class Car
    {
        /* Data Annotation Attributes;
         * - Required
         * - MaxLength, MinLength
         * - Range
         * - Phone
         * - CreditCard
         * - EmailAddres
         * - Url
         * - Compare
         * - RegularExpression
         */

        public int Id { get; set; }

        //[Required, MinLength(2)]
        public string? Name { get; set; }

        public int Year { get; set; }

        //[Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        //[Range(0, double.MaxValue)]
        public int Km { get; set; }

        public string? Fuel { get; set; }

        //[Required, MinLength(2)]
        public string? City { get; set; }

        public string? Transmission { get; set; }

        //[Url]
        public string? ImagePath { get; set; }

    }
}
