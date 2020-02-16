﻿using GnomeVillage.Application.Queries.Dtos;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.WebUI.Pages
{
   public partial class HabitantOverviewBase: ComponentBase
   {
      public IEnumerable<HabitantViewModel> Habitans { get; set; }
      public IEnumerable<string> Professions { get; set; }
      public IEnumerable<string> HairColors { get; set; }

      protected override async Task OnInitializedAsync()
      {
         await Task.WhenAll(
            InitProfessionList(),
            InitHairColorList(),
            InitHabitantList());
         
         await base.OnInitializedAsync();
      }

      private async Task InitHabitantList()
      {
         Habitans = new List<HabitantViewModel>
         {
            new HabitantViewModel
            {
               Age = 50,
               Friends =new string[] { } ,
               HairColor = "Grey" ,
               Height = 59.1m,
               Id = 1,
               Name= "Habi1",
               Professions = new string[] { Professions.ToArray()[0], Professions.ToArray()[1] },
               Thumbnail = "https://picsum.photos/id/237/200/300",
               Weight = 45.4m
            },
            new HabitantViewModel
            {
               Age = 53,
               Friends =new string[] { } ,
               HairColor = "Grey" ,
               Height = 9.1m,
               Id = 2,
               Name= "Habi2",
               Professions = new string[] { Professions.ToArray()[1], Professions.ToArray()[2] },
               Thumbnail = "https://i.picsum.photos/id/866/200/300.jpg",
               Weight = 45.4m
            },
            new HabitantViewModel
            {
               Age = 23,
               Friends =new string[] { } ,
               HairColor = "Blondie" ,
               Height = 9.1m,
               Id = 3,
               Name= "Habi3",
               Professions = new string[] { Professions.ToArray()[0]},
               Thumbnail = "https://i.picsum.photos/id/719/200/300.jpg?grayscale",
               Weight = 45.4m
            }
         };

         await Task.CompletedTask;
      }

      private async Task InitProfessionList()
      {
         Professions = new List<string> { "Doctor", "Architect", "Professor" };
         await Task.CompletedTask;
      }

      private async Task InitHairColorList()
      {
         HairColors = new List<string> { "Grey", "Dark", "Blondie" };
         await Task.CompletedTask;
      }
   }
}