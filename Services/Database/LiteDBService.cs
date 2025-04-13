// DZCP/Services/Database/LiteDBService.cs

using System;
using System.Collections.Generic;
using System.IO;
using LiteDB;
using DZCP.API.Interfaces;
using LiteDB.Engine;

namespace DZCP.Services.Database
{
    public class LiteDBService : ILiteDatabase
    {
        private LiteDatabase _db;

        public bool Connect(string connectionString)
        {
            try
            {
                _db = new LiteDatabase(connectionString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            _db?.Dispose();
        }

        public bool Ping()
        {
            return _db != null && !_db.UtcDate;
        }

        public void SaveData<T>(string key, T value)
        {
            var collection = _db.GetCollection<T>("data");
            collection.Upsert(key, value);
        }

        public T GetData<T>(string key)
        {
            var collection = _db.GetCollection<T>("data");
            return collection.FindById(key);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ILiteCollection<T> GetCollection<T>(string name, BsonAutoId autoId = BsonAutoId.ObjectId)
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<T> GetCollection<T>()
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<T> GetCollection<T>(BsonAutoId autoId)
        {
            throw new NotImplementedException();
        }

        public ILiteCollection<BsonDocument> GetCollection(string name, BsonAutoId autoId = BsonAutoId.ObjectId)
        {
            throw new NotImplementedException();
        }

        public bool BeginTrans()
        {
            throw new NotImplementedException();
        }

        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public bool Rollback()
        {
            throw new NotImplementedException();
        }

        public ILiteStorage<TFileId> GetStorage<TFileId>(string filesCollection = "_files", string chunksCollection = "_chunks")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetCollectionNames()
        {
            throw new NotImplementedException();
        }

        public bool CollectionExists(string name)
        {
            throw new NotImplementedException();
        }

        public bool DropCollection(string name)
        {
            throw new NotImplementedException();
        }

        public bool RenameCollection(string oldName, string newName)
        {
            throw new NotImplementedException();
        }

        public IBsonDataReader Execute(TextReader commandReader, BsonDocument parameters = null)
        {
            throw new NotImplementedException();
        }

        public IBsonDataReader Execute(string command, BsonDocument parameters = null)
        {
            throw new NotImplementedException();
        }

        public IBsonDataReader Execute(string command, params BsonValue[] args)
        {
            throw new NotImplementedException();
        }

        public void Checkpoint()
        {
            throw new NotImplementedException();
        }

        public long Rebuild(RebuildOptions options = null)
        {
            throw new NotImplementedException();
        }

        public BsonValue Pragma(string name)
        {
            throw new NotImplementedException();
        }

        public BsonValue Pragma(string name, BsonValue value)
        {
            throw new NotImplementedException();
        }

        public BsonMapper Mapper { get; }
        public ILiteStorage<string> FileStorage { get; }
        public int UserVersion { get; set; }
        public TimeSpan Timeout { get; set; }
        public bool UtcDate { get; set; }
        public long LimitSize { get; set; }
        public int CheckpointSize { get; set; }
        public Collation Collation { get; }
    }
}
