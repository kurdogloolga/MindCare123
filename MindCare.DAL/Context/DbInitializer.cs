﻿using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Entities;

namespace MindCare.DAL.Context
{
    public static class DbInitializer
    {
        public static void Initialize(MindCareDbContext context)
        {
            context.Database.MigrateAsync();

            if (context.Specialists.Any())
            {
                return;
            }

            var specialists = new List<Specialist>
            {
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Alice Smith",
                    Description = "Individual therapy specialists help clients cope with " +
                    "personal issues such as stress, anxiety, and depression. " +
                    "They offer personalized sessions to help you achieve emotional balance " +
                    "and improve your quality of life.",
                    Specialization = "Individual Therapy",
                    ImageUrl = "~/images/ind.jpeg",
                    PricePerSession = 100.00m,
                    Rating = 5
                },
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. John Doe",
                    Description = "Family therapists work with families " +
                    "to improve communication and resolve conflicts. " +
                    "They help strengthen relationships and create a harmonious family environment.",
                    Specialization = "Family Therapy",
                    ImageUrl = "~/images/fam.webp",
                    PricePerSession = 120.00m,
                    Rating = 3
                },
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Sarah Connor",
                    Description = "Group therapy provides an opportunity " +
                    "to share experiences and receive support from other participants. " +
                    "Specialists help participants develop communication skills " +
                    "and address common issues in a safe setting.",
                    Specialization = "Group Therapy",
                    ImageUrl = "~/images/gr.jpeg",
                    PricePerSession = 110.00m,
                    Rating = 4
                },
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Walter White",
                    Description = "Child therapy specialists help children deal with emotional " +
                    "and behavioral issues. They use play therapy and other methods " +
                    "to help children express their feelings and develop healthy skills.",
                    Specialization = "Child Therapy",
                    ImageUrl = "~/images/ch.jpg",
                    PricePerSession = 250.00m,
                    Rating = 4.4m
                },
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Gus Fring",
                    Description = "CBT specialists help clients change negative thoughts " +
                    "and behavioral patterns. This approach is effective " +
                    "for treating anxiety disorders, depression, and other mental health conditions.",
                    Specialization = "Cognitive Behavioral Therapy",
                    ImageUrl = "~/images/online.png",
                    PricePerSession = 90.00m,
                    Rating = 4.9m
                },
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Howard Hamlin",
                    Description = "Therapists specializing in trauma " +
                    "and PTSD help clients cope with the aftermath of traumatic events. " +
                    "They use proven methods to reduce symptoms and improve quality of life.",
                    Specialization = "Trauma & PTSD Therapy",
                    ImageUrl = "~/images/cbt.jpg",
                    PricePerSession = 190.00m,
                    Rating = 3.9m
                },
                new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Mike Ehrmantraut",
                    Description = "Coaches help clients set and achieve professional " +
                    "and personal goals. They offer strategies to improve career prospects " +
                    "and work-life balance.",
                    Specialization = "Career & Life Coaching",
                    ImageUrl = "~/images/traume.webp",
                    PricePerSession = 150.00m,
                    Rating = 4.8m
                },
                 new Specialist
                {
                    Id = Guid.NewGuid(),
                    FullName = "Dr. Skyler White",
                    Description = "Online therapists offer flexibility and convenience, " +
                    "allowing clients to receive help from anywhere. " +
                    "They specialize in various issues, including anxiety, depression, and stress.",
                    Specialization = "Online Therapy",
                    ImageUrl = "~/images/traume.webp",
                    PricePerSession = 150.00m,
                    Rating = 4.8m
                }

            };

            context.Specialists.AddRange(specialists);
            context.SaveChanges();
        }
    }
}
