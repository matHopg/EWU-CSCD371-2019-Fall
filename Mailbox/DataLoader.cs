using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; }
      
        public DataLoader(Stream source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public List<Mailbox> Load()
        {
            List<Mailbox> boxes = new List<Mailbox>();
            Source.Position = 0;

            try
            {
                using (StreamReader streamReader = new StreamReader(Source, leaveOpen: true))
                {
                    string curLine;
                    while ((curLine =streamReader.ReadLine()) != null)
                    {
                        Mailbox mailBox = JsonConvert.DeserializeObject<Mailbox>(curLine);
                        boxes.Add(mailBox);
                    }
                }
            }
            catch (JsonReaderException)
            {
                return null;
            }
            return boxes;

        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;

            using (StreamWriter streamWriter = new StreamWriter(Source, leaveOpen: true))
            {
                foreach(Mailbox mailbox in mailboxes)
                {
                    string json = JsonConvert.SerializeObject(mailbox);
                    streamWriter.WriteLine(json);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Source?.Dispose();
                }
                disposedValue = true;
            }
        }
        ~DataLoader()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
