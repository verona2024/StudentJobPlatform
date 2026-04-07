using System.Collections.Generic;
using StudentJobPlatform.Models;

namespace StudentJobPlatform.Data
{
    public static class DataSeeder
    {
        public static List<Job> SeedJobs()
        {
            return new List<Job>
            {
                new Job(1, "Software Developer Intern", "Assist in developing web applications using .NET and working with senior developers.", "Internships", "Prishtinë", "Part-Time", 300, 1),
                new Job(2, "Frontend Developer Intern", "Build user interfaces using HTML, CSS and JavaScript.", "Internships", "Prizren", "Part-Time", 280, 1),
                new Job(3, "Graphic Design Intern", "Create visual content for branding and social media campaigns.", "Internships", "Pejë", "Part-Time", 250, 1),
                new Job(4, "Marketing Intern", "Support digital marketing campaigns and promotional activities.", "Internships", "Gjilan", "Part-Time", 260, 1),
                new Job(5, "IT Support Intern", "Help troubleshoot software and hardware issues for staff.", "Internships", "Ferizaj", "Part-Time", 290, 1),

                new Job(6, "Call Center Agent", "Handle incoming calls and provide customer support.", "Part-Time Jobs", "Prishtinë", "Part-Time", 340, 2),
                new Job(7, "Waiter / Waitress", "Serve customers and manage table orders in a professional way.", "Part-Time Jobs", "Prizren", "Part-Time", 320, 2),
                new Job(8, "Shop Assistant", "Assist customers and organize products in the store.", "Part-Time Jobs", "Pejë", "Part-Time", 300, 2),
                new Job(9, "Receptionist", "Manage front desk tasks and welcome visitors.", "Part-Time Jobs", "Gjilan", "Part-Time", 360, 2),
                new Job(10, "Sales Assistant", "Support daily sales activities and customer service.", "Part-Time Jobs", "Prishtinë", "Part-Time", 350, 2),

                new Job(11, "Junior Web Developer", "Develop and maintain websites and web pages.", "Entry-Level", "Prishtinë", "Full-Time", 500, 3),
                new Job(12, "Junior Accountant", "Assist with bookkeeping, invoices and reports.", "Entry-Level", "Prizren", "Full-Time", 450, 3),
                new Job(13, "HR Assistant", "Support hiring processes and employee documentation.", "Entry-Level", "Pejë", "Full-Time", 430, 3),
                new Job(14, "Administrative Assistant", "Manage office documents and daily administrative tasks.", "Entry-Level", "Gjilan", "Full-Time", 470, 3),
                new Job(15, "IT Support Specialist", "Provide technical support and maintain company systems.", "Entry-Level", "Ferizaj", "Full-Time", 480, 3),

                new Job(16, "QA Intern", "Assist in software testing and reporting bugs.", "Internships", "Prishtinë", "Part-Time", 295, 1),
                new Job(17, "Digital Marketing Assistant", "Help with social media posts and online campaigns.", "Part-Time Jobs", "Prizren", "Part-Time", 310, 2),
                new Job(18, "Office Assistant", "Support office communication and document organization.", "Entry-Level", "Pejë", "Full-Time", 460, 3),
                new Job(19, "Cashier", "Handle payments and support customers at checkout.", "Part-Time Jobs", "Gjilan", "Part-Time", 300, 2),
                new Job(20, "Customer Support Intern", "Assist clients with basic support requests and follow-ups.", "Internships", "Ferizaj", "Part-Time", 285, 1)
            };
        }
    }
}
