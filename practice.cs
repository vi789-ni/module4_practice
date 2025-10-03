using System;

namespace DocumentFactoryMethod
{
    interface IDocument
    {
        void Open();
    }

    class Report : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыт отчет.");
        }
    }

    class Resume : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыто резюме.");
        }
    }

    class Letter : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыто письмо.");
        }
    }

    class Invoice : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Открыт счет-фактура.");
        }
    }

    abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument();
    }

    class ReportCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Report();
        }
    }

    class ResumeCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Resume();
        }
    }

    class LetterCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Letter();
        }
    }

    class InvoiceCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new Invoice();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип документа для создания:");
            Console.WriteLine("1 - Отчет");
            Console.WriteLine("2 - Резюме");
            Console.WriteLine("3 - Письмо");
            Console.WriteLine("4 - Счет-фактура");

            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            DocumentCreator creator = null;

            switch (choice)
            {
                case "1":
                    creator = new ReportCreator();
                    break;
                case "2":
                    creator = new ResumeCreator();
                    break;
                case "3":
                    creator = new LetterCreator();
                    break;
                case "4":
                    creator = new InvoiceCreator();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            IDocument document = creator.CreateDocument();
            document.Open();
        }
    }
}
