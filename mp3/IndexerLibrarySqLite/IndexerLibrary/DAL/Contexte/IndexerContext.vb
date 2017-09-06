Option Explicit On
Option Infer On
Option Strict On

Imports System.Data.Entity

Namespace Data

	Public Class IndexerContext

		Inherits ContextBase

		Public Property Files As DbSet(Of File)
		Public Property Folders As DbSet(Of Folder)
		Private _dbSets As New Dictionary(Of Type, DbSet)

		Public Sub New()
			MyBase.New(New System.Data.SQLite.SQLiteConnection("Data Source=p:\data.db;Version=3;"))
			_dbSets.Add(GetType(File), _Files)
			_dbSets.Add(GetType(Folder), _Folders)
		End Sub

		Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

			modelBuilder.Entity(Of File).ToTable(IndexerTableNames.files.ToString)
			modelBuilder.Entity(Of File).HasKey(Function(f) f.FileId).Property(Function(f) f.FileId).HasColumnName(IndexerFileProperties.file_id.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.IndexName).HasColumnName(IndexerFileProperties.index_name.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Path).HasColumnName(IndexerFileProperties.path.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Name).HasColumnName(IndexerFileProperties.name.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Artist).HasColumnName(IndexerFileProperties.artist.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Album).HasColumnName(IndexerFileProperties.album.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Title).HasColumnName(IndexerFileProperties.title.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Track).HasColumnName(IndexerFileProperties.track.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Year).HasColumnName(IndexerFileProperties.year.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Comment).HasColumnName(IndexerFileProperties.comment.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Genre).HasColumnName(IndexerFileProperties.genre.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Size).HasColumnName(IndexerFileProperties.size.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Duration).HasColumnName(IndexerFileProperties.duration.ToString)
			modelBuilder.Entity(Of File).Property(Function(f) f.Bitrate).HasColumnName(IndexerFileProperties.bitrate.ToString)

			modelBuilder.Entity(Of Folder).ToTable(IndexerTableNames.folders.ToString)
			modelBuilder.Entity(Of Folder).HasKey(Function(fld) fld.FolderId).Property(Function(f) f.FolderId).HasColumnName(IndexerFolderProperties.folder_id.ToString)
			modelBuilder.Entity(Of Folder).Property(Function(fld) fld.IndexName).HasColumnName(IndexerFolderProperties.index_name.ToString)
			modelBuilder.Entity(Of Folder).Property(Function(fld) fld.Path).HasColumnName(IndexerFolderProperties.path.ToString)
			modelBuilder.Entity(Of Folder).Property(Function(fld) fld.RootFolderPath).HasColumnName(IndexerFolderProperties.root_folder.ToString)
			modelBuilder.Entity(Of Folder).Property(Function(fld) fld.LastWriteTime).HasColumnName(IndexerFolderProperties.last_write_time.ToString)

			'modelBuilder.Entity(Of File).HasRequired(Function(f) f.Folder).WithMany(Function(fld) fld.Files)

			MyBase.OnModelCreating(modelBuilder)
		End Sub

		Public Overrides ReadOnly Property DbSets As Dictionary(Of Type, DbSet)
		Get
			Return _dbSets
		End Get
		End Property
	End Class



Public Class aa

	Inherits DbContext



End Class
End Namespace

