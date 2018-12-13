namespace Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TravelDatabase : DbContext
    {
        public TravelDatabase()
            : base("name=TravelDatabase")
        {
        }

        public virtual DbSet<DiaDanh> DiaDanhs { get; set; }
        public virtual DbSet<HuongDanVien> HuongDanViens { get; set; }
        public virtual DbSet<ImageTour> ImageTours { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<PhieuDatTour> PhieuDatTours { get; set; }
        public virtual DbSet<PhuongTien> PhuongTiens { get; set; }
        public virtual DbSet<ThamSo> ThamSoes { get; set; }
        public virtual DbSet<ThongTinChiTietTour> ThongTinChiTietTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhieuDatTour>()
                .Property(e => e.MaTour)
                .IsFixedLength();

            modelBuilder.Entity<PhieuDatTour>()
                .Property(e => e.MaKhachHang)
                .IsFixedLength();

            modelBuilder.Entity<ThongTinChiTietTour>()
                .Property(e => e.MaPhuongTien)
                .IsFixedLength();

            modelBuilder.Entity<ThongTinChiTietTour>()
                .Property(e => e.MaLuuY)
                .IsFixedLength();

            modelBuilder.Entity<Tour>()
                .Property(e => e.MaChiTietTour)
                .IsFixedLength();

            modelBuilder.Entity<Tour>()
                .Property(e => e.MaHuongDanVien)
                .IsFixedLength();

            modelBuilder.Entity<Tour>()
                .Property(e => e.MaDiaDanh)
                .IsFixedLength();
        }
    }
}
