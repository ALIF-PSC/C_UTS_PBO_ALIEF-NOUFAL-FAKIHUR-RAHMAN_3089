using System;
using System.Collections.Generic;
using system.linq;

public abstract class Mahasiswa
{
    public string Nama; 
    public string Jurusan;
    public int NIM;

    public abstract void Datamahasiswa()
}

public class Create : Mahasiswa
{
    public Create(string nama, string jurusan, int NIM)
    {
        Nama = nama;
        Jurusan = jurusan;
        NIM = NIM;
    }

    public override void Datamahasiswa()
    {
        Console.WriteLine($", Nama: {Nama}, Jurusan: {Jurusan}, NIM {NIM}");
    }
}

public class isiMahasiswa 
{
    public List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

    public void MahasiswaBARU(Mahasiswa mahasiswa)
    {
        if (daftarMahasiswa.Any(m => m.NIM == mahasiswa.NIM))
        {
            Console.WriteLine(" NIM sudah digunakan.");
            return;
        }
        daftarMahasiswa.Add(mahasiswa);
        Console.WriteLine("Mahasiswa berhasil ditambahkan.");
    }

    public void LihatdaftarMahasiswa()
    {
        if (daftarMahasiswa.Count == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.");
            return;
        }

        foreach (var mahasiswa in daftarMahasiswa)
        {
            mahasiswa.Tampilkanmahasiswa();
        }
    }

    public void UpdateMahasiswa(string nim)
    {
        var mahasiswa = daftarMahasiswa.Default(m => m.NIM == nim);
        if (mahasiswa == null)
        {
            Console.WriteLine("Error: NIM tidak ditemukan.");
            return;
        }

        Console.Write("Masukkan Nama Baru: ");
        mahasiswa.Nama = Console.ReadLine();

        Console.Write("Masukkan Jurusan Baru: ");
        mahasiswa.Jurusan = Console.ReadLine();

        Console.WriteLine("Data mahasiswa berhasil dimasukkan .");
    }
    public void HapusMahasiswa(string nim)
    {
        var mhs = daftarMahasiswa.Default(m => m.NIM == nim);
        if (mhs == null)
        {
            Console.WriteLine("Error: NIM tidak ditemukan.");
            return;
        }

        daftarMahasiswa.Remove(mhs);
        Console.WriteLine("Data mahasiswa berhasil dihapus.");
    }
}

public class program
{
    static void Main(string[] args)
    {
        isiMahasiswa mhasiswa = new isiMahasiswa();
        int pilihan;

        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu (1-5): ");
            int.TryParse(Console.ReadLine(), out pilihan);

          