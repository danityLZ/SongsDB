using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private Song1SystemDBContext context = new Song1SystemDBContext();
        private GenericRepository<Song> songRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Rating> ratingRepository;

        public GenericRepository<Song> SongRepository
        {
            get
            {
                if (this.songRepository == null)
                {
                    this.songRepository = new GenericRepository<Song>(context);
                }

                return songRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }

                return userRepository;
            }
        }

        public GenericRepository<Rating> RatingRepository
        {
            get
            {
                if (this.ratingRepository == null)
                {
                    this.ratingRepository = new GenericRepository<Rating>(context);
                }

                return ratingRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            }
        }

    }
