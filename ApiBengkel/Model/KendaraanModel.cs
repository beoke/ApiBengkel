namespace ApiBengkel.Model
{
    public class KendaraanModel
    {
        public string ktp_pelanggan { get; set; }
        public string nama_pelanggan { get; set; }
        public int id_kendaraan { get; set; }
        public string no_pol { get; set; }
        public string merk { get; set; }
        public string tipe { get; set; }
        public string transmisi { get; set; }
        public int kapasitas { get; set; }
        public string tahun { get; set; }
        public int total_servis { get; set; } = 0;
    }
}
