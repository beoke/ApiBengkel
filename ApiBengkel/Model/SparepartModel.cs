namespace ApiBengkel.Model
{
    public class SparepartModel
    {

        public string kode_sparepart { get; set; }
        public string nama_sparepart { get; set; }
        public int stok { get; set; }
        public int stok_minimum { get; set; }
        public int harga { get; set; }
        public byte[] image_data { get; set; }
    }
}
