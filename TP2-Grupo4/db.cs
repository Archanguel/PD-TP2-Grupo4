using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public class db
    {
		private const string DEL = ",";
		private string _ruta = Application.StartupPath + "\\db\\";
		public string Tabla { get; set; }
		public db(string t) { Tabla = t; carpeta(); }
		//public db(string t) { Tabla = t; carpeta(); if (!Existe("alojamientos")) CrearTabla("alojamientos", new string[] { "Código","Ciudad","Barrio","Estrellas","Cant. Pers.","TV","Tipo","Precio Pers.","Precio Día","Habitaciones","Baños" }); }

		/* Crear tablas */
		public static void CrearTabla(string n, string[] col)
		{
			if (!Directory.Exists(Application.StartupPath + "\\db\\")) Directory.CreateDirectory(Application.StartupPath + "\\db\\");
			string ruta = Application.StartupPath + "\\db\\" + n + ".txt";
			File.WriteAllText(ruta, string.Join(DEL, col));
			//File.WriteAllText(ruta, string.Format(DEL, col));
		}

		/* Eliminar tablas */
		public static void EliminarTabla(string n)
		{
			string ruta = Application.StartupPath + "\\db\\" + n + ".txt";
			if (File.Exists(ruta)) File.Delete(ruta);
		}
		public static bool Existe(string nombre) { return File.Exists(Application.StartupPath + "\\db\\" + nombre + ".txt"); }
		/**********************/
		public void Insertar(List<string> valores)
		{
			excepcion();
			File.AppendAllText(Ruta(), "\r\n" + string.Join(DEL, valores));
		}

		private string actualizar = "\r\n";
		public void Actualizar(Func<string, bool> b, int index, List<string> valores)
		{
			excepcion();
			string[] lineas = SplitLINEAS(File.ReadAllText(Ruta()));
			string txt_nuevo = lineas[0];
			for (int i = 1; i < lineas.Length; i++)
				txt_nuevo += b(SplitDEL(lineas[i])[index]) ? actualizar + string.Join(DEL, valores) : "\r\n" + lineas[i];
			File.WriteAllText(Ruta(), txt_nuevo);
		}

		public void Eliminar(Func<string, bool> b, int index)
		{
			actualizar = "";
			Actualizar(b, index, new List<string>());
			actualizar = "\r\n";
		}

		/* Buscar tablas */
		public List<List<string>> Buscar(Func<string, bool> b, int index, bool col)
		{
			excepcion();
			string txt = File.ReadAllText(Ruta());
			List<List<string>> r = new List<List<string>>();
			if (col) r.Add(SplitDEL(SplitLINEAS(txt)[0]).ToList());

			for (int i = 1; i < SplitLINEAS(txt).Length; i++)
			{
				string celda = SplitDEL(SplitLINEAS(txt)[i])[index];
				if (b(celda)) r.Add(SplitDEL(SplitLINEAS(txt)[i]).ToList());
			}
			return r;
		}

		public List<List<string>> Abrir() { return Buscar(x => x.Length >= 0, 0, true); }

		/* Ver en DataGridView */
		public void VerEnDGV(DataGridView d, List<List<string>> t)
		{
			d.Rows.Clear(); d.Columns.Clear();
			for (int i = 0; i < t[0].Count; i++) d.Columns.Add(t[0][i], t[0][i]);
			for (int i = 1; i < t.Count; i++)
			{
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(d);
				for (int x = 0; x < t[i].Count; x++) row.Cells[x].Value = t[i][x];
				d.Rows.Add(row);
			}
		}

		/******************/
		private string Ruta() { return _ruta + Tabla + ".txt"; }
		private void excepcion() { if (Tabla == "" || !File.Exists(Ruta())) throw new Exception("Tabla no encontrada."); }
		private void carpeta() { if (!Directory.Exists(_ruta)) Directory.CreateDirectory(_ruta); }
		private string[] SplitDEL(string txt) { return txt.Split(new string[] { DEL }, StringSplitOptions.None); }
		private string[] SplitLINEAS(string txt) { return txt.Split(new string[] { "\r\n" }, StringSplitOptions.None); }
	}
}
