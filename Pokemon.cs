﻿using System.Text.Json;
using System.Net;

namespace Pokedex
{
    internal class Pokemon
    {
        private int generation;
        private Data data;

        public int Generation
        {
            get
            {
                return this.generation;
            }
        }

        public int Id
        {
            get
            {
                return this.data.id;
            }
        }

        public List<string> Types
        {
            get
            {
                return this.data.types
                    .ConvertAll(t => t.ToLower())
                    .ToList();
            }
        }

        public List<Statistic> Statistics
        {
            get
            {
                return this.data.stats;
            }
        }

        public int LastEdit
        {
            get
            {
                return this.data.lastEdit;
            }
        }

        public Pokemon(int id)
        {
            this.data = Downloader.GetData(id);

            this.generation = Pokedex.Generation.Get(id);
        }

        public String CondensedDisplay()
        {
            return $"[{this.data.id}] {this.data.name.fr}";
        }
    }
}