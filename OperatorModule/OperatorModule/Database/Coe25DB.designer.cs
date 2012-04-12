﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OperatorModule.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Coe25")]
	public partial class Coe25DBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttbl_Administrator(tbl_Administrator instance);
    partial void Updatetbl_Administrator(tbl_Administrator instance);
    partial void Deletetbl_Administrator(tbl_Administrator instance);
    partial void Inserttbl_Post(tbl_Post instance);
    partial void Updatetbl_Post(tbl_Post instance);
    partial void Deletetbl_Post(tbl_Post instance);
    partial void Inserttbl_Cluster(tbl_Cluster instance);
    partial void Updatetbl_Cluster(tbl_Cluster instance);
    partial void Deletetbl_Cluster(tbl_Cluster instance);
    partial void Inserttbl_Map(tbl_Map instance);
    partial void Updatetbl_Map(tbl_Map instance);
    partial void Deletetbl_Map(tbl_Map instance);
    partial void Inserttbl_History(tbl_History instance);
    partial void Updatetbl_History(tbl_History instance);
    partial void Deletetbl_History(tbl_History instance);
    #endregion
		
		public Coe25DBDataContext() : 
				base(global::OperatorModule.Properties.Settings.Default.Coe25ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public Coe25DBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Coe25DBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Coe25DBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Coe25DBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbl_Administrator> tbl_Administrators
		{
			get
			{
				return this.GetTable<tbl_Administrator>();
			}
		}
		
		public System.Data.Linq.Table<tbl_Post> tbl_Posts
		{
			get
			{
				return this.GetTable<tbl_Post>();
			}
		}
		
		public System.Data.Linq.Table<tbl_Cluster> tbl_Clusters
		{
			get
			{
				return this.GetTable<tbl_Cluster>();
			}
		}
		
		public System.Data.Linq.Table<tbl_Map> tbl_Maps
		{
			get
			{
				return this.GetTable<tbl_Map>();
			}
		}
		
		public System.Data.Linq.Table<tbl_History> tbl_Histories
		{
			get
			{
				return this.GetTable<tbl_History>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_Administrator")]
	public partial class tbl_Administrator : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Username;
		
		private string _Password;
		
		private string _Salt;
		
		private string _SerialNumber;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnSaltChanging(string value);
    partial void OnSaltChanged();
    partial void OnSerialNumberChanging(string value);
    partial void OnSerialNumberChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    #endregion
		
		public tbl_Administrator()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50)")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Salt", DbType="VarChar(50)")]
		public string Salt
		{
			get
			{
				return this._Salt;
			}
			set
			{
				if ((this._Salt != value))
				{
					this.OnSaltChanging(value);
					this.SendPropertyChanging();
					this._Salt = value;
					this.SendPropertyChanged("Salt");
					this.OnSaltChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SerialNumber", DbType="VarChar(50)")]
		public string SerialNumber
		{
			get
			{
				return this._SerialNumber;
			}
			set
			{
				if ((this._SerialNumber != value))
				{
					this.OnSerialNumberChanging(value);
					this.SendPropertyChanging();
					this._SerialNumber = value;
					this.SendPropertyChanged("SerialNumber");
					this.OnSerialNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_Post")]
	public partial class tbl_Post : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _PostName;
		
		private string _PostSerialNumber;
		
		private System.Nullable<int> _Cluster;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private EntitySet<tbl_Map> _tbl_Maps;
		
		private EntitySet<tbl_History> _tbl_Histories;
		
		private EntityRef<tbl_Cluster> _tbl_Cluster;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPostNameChanging(string value);
    partial void OnPostNameChanged();
    partial void OnPostSerialNumberChanging(string value);
    partial void OnPostSerialNumberChanged();
    partial void OnClusterChanging(System.Nullable<int> value);
    partial void OnClusterChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    #endregion
		
		public tbl_Post()
		{
			this._tbl_Maps = new EntitySet<tbl_Map>(new Action<tbl_Map>(this.attach_tbl_Maps), new Action<tbl_Map>(this.detach_tbl_Maps));
			this._tbl_Histories = new EntitySet<tbl_History>(new Action<tbl_History>(this.attach_tbl_Histories), new Action<tbl_History>(this.detach_tbl_Histories));
			this._tbl_Cluster = default(EntityRef<tbl_Cluster>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostName", DbType="VarChar(50)")]
		public string PostName
		{
			get
			{
				return this._PostName;
			}
			set
			{
				if ((this._PostName != value))
				{
					this.OnPostNameChanging(value);
					this.SendPropertyChanging();
					this._PostName = value;
					this.SendPropertyChanged("PostName");
					this.OnPostNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostSerialNumber", DbType="VarChar(50)")]
		public string PostSerialNumber
		{
			get
			{
				return this._PostSerialNumber;
			}
			set
			{
				if ((this._PostSerialNumber != value))
				{
					this.OnPostSerialNumberChanging(value);
					this.SendPropertyChanging();
					this._PostSerialNumber = value;
					this.SendPropertyChanged("PostSerialNumber");
					this.OnPostSerialNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cluster", DbType="Int")]
		public System.Nullable<int> Cluster
		{
			get
			{
				return this._Cluster;
			}
			set
			{
				if ((this._Cluster != value))
				{
					if (this._tbl_Cluster.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnClusterChanging(value);
					this.SendPropertyChanging();
					this._Cluster = value;
					this.SendPropertyChanged("Cluster");
					this.OnClusterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_Post_tbl_Map", Storage="_tbl_Maps", ThisKey="ID", OtherKey="PostID")]
		public EntitySet<tbl_Map> tbl_Maps
		{
			get
			{
				return this._tbl_Maps;
			}
			set
			{
				this._tbl_Maps.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_Post_tbl_History", Storage="_tbl_Histories", ThisKey="ID", OtherKey="PostID")]
		public EntitySet<tbl_History> tbl_Histories
		{
			get
			{
				return this._tbl_Histories;
			}
			set
			{
				this._tbl_Histories.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_Cluster_tbl_Post", Storage="_tbl_Cluster", ThisKey="Cluster", OtherKey="ID", IsForeignKey=true)]
		public tbl_Cluster tbl_Cluster
		{
			get
			{
				return this._tbl_Cluster.Entity;
			}
			set
			{
				tbl_Cluster previousValue = this._tbl_Cluster.Entity;
				if (((previousValue != value) 
							|| (this._tbl_Cluster.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbl_Cluster.Entity = null;
						previousValue.tbl_Posts.Remove(this);
					}
					this._tbl_Cluster.Entity = value;
					if ((value != null))
					{
						value.tbl_Posts.Add(this);
						this._Cluster = value.ID;
					}
					else
					{
						this._Cluster = default(Nullable<int>);
					}
					this.SendPropertyChanged("tbl_Cluster");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbl_Maps(tbl_Map entity)
		{
			this.SendPropertyChanging();
			entity.tbl_Post = this;
		}
		
		private void detach_tbl_Maps(tbl_Map entity)
		{
			this.SendPropertyChanging();
			entity.tbl_Post = null;
		}
		
		private void attach_tbl_Histories(tbl_History entity)
		{
			this.SendPropertyChanging();
			entity.tbl_Post = this;
		}
		
		private void detach_tbl_Histories(tbl_History entity)
		{
			this.SendPropertyChanging();
			entity.tbl_Post = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_Cluster")]
	public partial class tbl_Cluster : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _UniqueCode;
		
		private string _ClusterPhoneNumber;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private EntitySet<tbl_Post> _tbl_Posts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUniqueCodeChanging(string value);
    partial void OnUniqueCodeChanged();
    partial void OnClusterPhoneNumberChanging(string value);
    partial void OnClusterPhoneNumberChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    #endregion
		
		public tbl_Cluster()
		{
			this._tbl_Posts = new EntitySet<tbl_Post>(new Action<tbl_Post>(this.attach_tbl_Posts), new Action<tbl_Post>(this.detach_tbl_Posts));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UniqueCode", DbType="VarChar(50)")]
		public string UniqueCode
		{
			get
			{
				return this._UniqueCode;
			}
			set
			{
				if ((this._UniqueCode != value))
				{
					this.OnUniqueCodeChanging(value);
					this.SendPropertyChanging();
					this._UniqueCode = value;
					this.SendPropertyChanged("UniqueCode");
					this.OnUniqueCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClusterPhoneNumber", DbType="VarChar(50)")]
		public string ClusterPhoneNumber
		{
			get
			{
				return this._ClusterPhoneNumber;
			}
			set
			{
				if ((this._ClusterPhoneNumber != value))
				{
					this.OnClusterPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._ClusterPhoneNumber = value;
					this.SendPropertyChanged("ClusterPhoneNumber");
					this.OnClusterPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_Cluster_tbl_Post", Storage="_tbl_Posts", ThisKey="ID", OtherKey="Cluster")]
		public EntitySet<tbl_Post> tbl_Posts
		{
			get
			{
				return this._tbl_Posts;
			}
			set
			{
				this._tbl_Posts.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbl_Posts(tbl_Post entity)
		{
			this.SendPropertyChanging();
			entity.tbl_Cluster = this;
		}
		
		private void detach_tbl_Posts(tbl_Post entity)
		{
			this.SendPropertyChanging();
			entity.tbl_Cluster = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_Map")]
	public partial class tbl_Map : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _PostID;
		
		private string _Latitude;
		
		private string _Longitude;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private EntityRef<tbl_Post> _tbl_Post;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPostIDChanging(System.Nullable<int> value);
    partial void OnPostIDChanged();
    partial void OnLatitudeChanging(string value);
    partial void OnLatitudeChanged();
    partial void OnLongitudeChanging(string value);
    partial void OnLongitudeChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    #endregion
		
		public tbl_Map()
		{
			this._tbl_Post = default(EntityRef<tbl_Post>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostID", DbType="Int")]
		public System.Nullable<int> PostID
		{
			get
			{
				return this._PostID;
			}
			set
			{
				if ((this._PostID != value))
				{
					if (this._tbl_Post.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPostIDChanging(value);
					this.SendPropertyChanging();
					this._PostID = value;
					this.SendPropertyChanged("PostID");
					this.OnPostIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="VarChar(50)")]
		public string Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				if ((this._Latitude != value))
				{
					this.OnLatitudeChanging(value);
					this.SendPropertyChanging();
					this._Latitude = value;
					this.SendPropertyChanged("Latitude");
					this.OnLatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="VarChar(50)")]
		public string Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				if ((this._Longitude != value))
				{
					this.OnLongitudeChanging(value);
					this.SendPropertyChanging();
					this._Longitude = value;
					this.SendPropertyChanged("Longitude");
					this.OnLongitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_Post_tbl_Map", Storage="_tbl_Post", ThisKey="PostID", OtherKey="ID", IsForeignKey=true)]
		public tbl_Post tbl_Post
		{
			get
			{
				return this._tbl_Post.Entity;
			}
			set
			{
				tbl_Post previousValue = this._tbl_Post.Entity;
				if (((previousValue != value) 
							|| (this._tbl_Post.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbl_Post.Entity = null;
						previousValue.tbl_Maps.Remove(this);
					}
					this._tbl_Post.Entity = value;
					if ((value != null))
					{
						value.tbl_Maps.Add(this);
						this._PostID = value.ID;
					}
					else
					{
						this._PostID = default(Nullable<int>);
					}
					this.SendPropertyChanged("tbl_Post");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_History")]
	public partial class tbl_History : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _PostID;
		
		private string _SessionGUID;
		
		private System.Nullable<bool> _IsFixed;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private EntityRef<tbl_Post> _tbl_Post;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPostIDChanging(System.Nullable<int> value);
    partial void OnPostIDChanged();
    partial void OnSessionGUIDChanging(string value);
    partial void OnSessionGUIDChanged();
    partial void OnIsFixedChanging(System.Nullable<bool> value);
    partial void OnIsFixedChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    #endregion
		
		public tbl_History()
		{
			this._tbl_Post = default(EntityRef<tbl_Post>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostID", DbType="Int")]
		public System.Nullable<int> PostID
		{
			get
			{
				return this._PostID;
			}
			set
			{
				if ((this._PostID != value))
				{
					if (this._tbl_Post.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPostIDChanging(value);
					this.SendPropertyChanging();
					this._PostID = value;
					this.SendPropertyChanged("PostID");
					this.OnPostIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SessionGUID", DbType="VarChar(100)")]
		public string SessionGUID
		{
			get
			{
				return this._SessionGUID;
			}
			set
			{
				if ((this._SessionGUID != value))
				{
					this.OnSessionGUIDChanging(value);
					this.SendPropertyChanging();
					this._SessionGUID = value;
					this.SendPropertyChanged("SessionGUID");
					this.OnSessionGUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsFixed", DbType="Bit")]
		public System.Nullable<bool> IsFixed
		{
			get
			{
				return this._IsFixed;
			}
			set
			{
				if ((this._IsFixed != value))
				{
					this.OnIsFixedChanging(value);
					this.SendPropertyChanging();
					this._IsFixed = value;
					this.SendPropertyChanged("IsFixed");
					this.OnIsFixedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_Post_tbl_History", Storage="_tbl_Post", ThisKey="PostID", OtherKey="ID", IsForeignKey=true)]
		public tbl_Post tbl_Post
		{
			get
			{
				return this._tbl_Post.Entity;
			}
			set
			{
				tbl_Post previousValue = this._tbl_Post.Entity;
				if (((previousValue != value) 
							|| (this._tbl_Post.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbl_Post.Entity = null;
						previousValue.tbl_Histories.Remove(this);
					}
					this._tbl_Post.Entity = value;
					if ((value != null))
					{
						value.tbl_Histories.Add(this);
						this._PostID = value.ID;
					}
					else
					{
						this._PostID = default(Nullable<int>);
					}
					this.SendPropertyChanged("tbl_Post");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
