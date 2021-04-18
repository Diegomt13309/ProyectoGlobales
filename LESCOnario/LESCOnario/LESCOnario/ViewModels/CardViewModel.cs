
using LESCOnario.Models;
using LESCOnario.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace LESCOnario.ViewModels
{
    public class CardViewModel 
    {
        public ObservableCollection<CardModel> Cards { get; set; }

        public CardViewModel() {
            Cards = new ObservableCollection<CardModel>
            {
                new CardModel
                {
                    Letter = "A",
                    Image = "a.png"
                },
                new CardModel
                {
                    Letter = "B",
                    Image = "b.jpg"
                },
                new CardModel
                {
                    Letter = "C",
                    Image = "c.jpg"
                },
                new CardModel
                {
                    Letter = "CH",
                    Image = "ch.jpg"
                },
                new CardModel
                {
                    Letter = "D",
                    Image = "d.jpg"
                },
                new CardModel
                {
                    Letter = "E",
                    Image = "e.jpg"
                },
                new CardModel
                {
                    Letter = "F",
                    Image = "f.jpg"
                },
                new CardModel
                {
                    Letter = "G",
                    Image = "g.jpg"
                },
                new CardModel
                {
                    Letter = "H",
                    Image = "h.jpg"
                },
                new CardModel
                {
                    Letter = "I",
                    Image = "i.jpg"
                },
                new CardModel
                {
                    Letter = "J",
                    Image = "j.jpg"
                },
                new CardModel
                {
                    Letter = "K",
                    Image = "k.jpg"
                },
                new CardModel
                {
                    Letter = "L",
                    Image = "l.jpg"
                },
                new CardModel
                {
                    Letter = "LL",
                    Image = "ll.jpg"
                },
                new CardModel
                {
                    Letter = "M",
                    Image = "m.jpg"
                },
                new CardModel
                {
                    Letter = "N",
                    Image = "n.jpg"
                },
                new CardModel
                {
                    Letter = "Ñ",
                    Image = "nn.jpg"
                },
                new CardModel
                {
                    Letter = "O",
                    Image = "o.jpg"
                },
                new CardModel
                {
                    Letter = "P",
                    Image = "p.jpg"
                },
                new CardModel
                {
                    Letter = "Q",
                    Image = "q.jpg"
                },
                new CardModel
                {
                    Letter = "R",
                    Image = "r.jpg"
                },
                new CardModel
                {
                    Letter = "RR",
                    Image = "rr.jpg"
                },
                new CardModel
                {
                    Letter = "S",
                    Image = "s.jpg"
                },
                new CardModel
                {
                    Letter = "T",
                    Image = "t.jpg"
                },
                new CardModel
                {
                    Letter = "U",
                    Image = "u.jpg"
                },
                new CardModel
                {
                    Letter = "V",
                    Image = "v.jpg"
                },
                new CardModel
                {
                    Letter = "W",
                    Image = "w.jpg"
                },
                new CardModel
                {
                    Letter = "X",
                    Image = "x.jpg"
                },
                new CardModel
                {
                    Letter = "Y",
                    Image = "y.jpg"
                },
                new CardModel
                {
                    Letter = "Z",
                    Image = "z.jpg"
                }
            };
        }
    }
}
