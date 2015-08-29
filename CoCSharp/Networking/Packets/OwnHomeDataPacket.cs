﻿using CoCSharp.Logic;
using Ionic.Zlib;
using System;
using System.IO;
using System.Text;

namespace CoCSharp.Networking.Packets
{
    public class OwnHomeDataPacket : IPacket
    {
        public ushort ID { get { return 0x5E25; } }

        public TimeSpan LastVisit;
        public int Unknown1;
        public DateTime Timestamp;
        public int Unknown2;
        public long UserID;
        public TimeSpan ShieldDuration;
        public int Unknown3;
        public int Unknown4;
        public bool Compressed;
        public Village Home;
        public Avatar Avatar;
        public int Unknown6;
        public long UserID1;
        public long UserID2;
        public bool Unknown7;
        public long Unknown8;
        public bool Unknown9;
        public long Unknown10;
        public int Unknown11;
        public int AllianceCastleLevel;
        public int AllianceCastleUnitCapacity;
        public int AllianceCastleUnitCount;
        public string FacebookID;
        public int Gems1;
        public int Unknown14;
        public int Unknown15;
        public int Unknown16;
        public int Unknown18;
        public int Unknown17;
        public bool Unknown19;
        public long Unknown20;
        public byte Unknown21;
        public int Unknown22;
        public int Unknown23;
        public int Unknown24;
        public int Unknown25;
        public int Unknown28;
        public int Unknown27;
        public int Unknown26;

        public void ReadPacket(PacketReader reader)
        {
            var offset = 0x2A;
            LastVisit = TimeSpan.FromSeconds(reader.ReadInt32());
            Unknown1 = reader.ReadInt32();
            Timestamp = DateTimeConverter.FromUnixTimestamp(reader.ReadInt32());
            Unknown2 = reader.ReadInt32();
            UserID = reader.ReadInt64();
            ShieldDuration = TimeSpan.FromSeconds(reader.ReadInt32());
            Unknown3 = reader.ReadInt32();
            Unknown4 = reader.ReadInt32();
            Compressed = reader.ReadBoolean();
            Home = new Village();
            Home.Read(reader);

            Avatar = new Avatar();
            // Seems like a whole object
            Unknown6 = reader.ReadInt32();
            UserID1 = reader.ReadInt64();
            UserID2 = reader.ReadInt64();
            Avatar.ID = UserID1;

            switch (reader.ReadByte())
            {
                case 0:
                    break;

                case 1:
                    Avatar.Clan = new Clan();
                    Avatar.Clan.ID = reader.ReadInt64();
                    Avatar.Clan.Name = reader.ReadString();
                    Avatar.Clan.Badge = reader.ReadInt32();
                    reader.ReadInt32();
                    Avatar.Clan.Level = reader.ReadInt32();
                    offset += 1;
                    break;

                case 2: // clanless but clan castle built?
                    var lel = reader.ReadInt64();
                    break;
            }

            if (Unknown7 = reader.ReadBoolean())
                Unknown8 = reader.ReadInt64();

            if (Unknown9 = reader.ReadBoolean())
                Unknown10 = reader.ReadInt64();

            reader.Seek(offset, SeekOrigin.Current);
            Unknown11 = reader.ReadInt32(); 
            AllianceCastleLevel = reader.ReadInt32(); // -1 if not constructed
            AllianceCastleUnitCapacity = reader.ReadInt32();
            AllianceCastleUnitCount = reader.ReadInt32();
            Avatar.TownHallLevel = reader.ReadInt32();
            Avatar.Username = reader.ReadString();
            FacebookID = reader.ReadString();
            Avatar.Level = reader.ReadInt32();
            Avatar.Experience = reader.ReadInt32();
            Avatar.Gems = reader.ReadInt32();
            Gems1 = reader.ReadInt32();
            Unknown14 = reader.ReadInt32();
            Unknown15 = reader.ReadInt32();
            Avatar.Trophies = reader.ReadInt32();
            Avatar.AttacksWon = reader.ReadInt32();
            Avatar.AttacksLost = reader.ReadInt32();
            Avatar.DefencesWon = reader.ReadInt32();
            Avatar.DefencesLost = reader.ReadInt32();
            Unknown16 = reader.ReadInt32();
            Unknown17 = reader.ReadInt32();
            Unknown18 = reader.ReadInt32();
            if (Unknown19 = reader.ReadBoolean())
                Unknown20 = reader.ReadInt64();
            Unknown21 = reader.ReadByte();
            Unknown22 = reader.ReadInt32();
            Unknown23 = reader.ReadInt32();
            Unknown24 = reader.ReadInt32();
            Unknown25 = reader.ReadInt32();

            var count1 = reader.ReadInt32();
            for (int i = 0; i < count1; i++)
            {
                var id = reader.ReadInt32(); // resource id from resources.csv
                var capacity = reader.ReadInt32();
            }

            var count2 = reader.ReadInt32();
            for (int i = 0; i < count2; i++)
            {
                var id = reader.ReadInt32(); // resource id from resources.csv
                var amount = reader.ReadInt32();
            }

            var count3 = reader.ReadInt32();
            for (int i = 0; i < count3; i++)
            {
                var id = reader.ReadInt32(); // unit id from characters.csv
                var amount = reader.ReadInt32();
            }

            var count4 = reader.ReadInt32();
            for (int i = 0; i < count4; i++)
            {
                var id = reader.ReadInt32(); // spell id from spells.csv
                var amount = reader.ReadInt32();
            }

            var count5 = reader.ReadInt32();
            for (int i = 0; i < count5; i++)
            {
                var id = reader.ReadInt32(); // unit id from characters.csv
                var level = reader.ReadInt32();
            }

            var count6 = reader.ReadInt32();
            for (int i = 0; i < count6; i++)
            {
                var id = reader.ReadInt32(); // spell id from spells.csv
                var level = reader.ReadInt32();
            }

            var count7 = reader.ReadInt32();
            for (int i = 0; i < count7; i++)
            {
                var id = reader.ReadInt32(); // hero id from heros.csv
                var level = reader.ReadInt32();
            }

            var count8 = reader.ReadInt32();
            for (int i = 0; i < count8; i++)
            {
                var id = reader.ReadInt32(); // hero id from heros.csv
                var health = reader.ReadInt32();
            }

            var count9 = reader.ReadInt32();
            for (int i = 0; i < count9; i++)
            {
                var id = reader.ReadInt32(); // hero id from heros.csv
                var state = reader.ReadInt32();
            }

            var count10 = reader.ReadInt32();
            for (int i = 0; i < count10; i++)
            {
                var id = reader.ReadInt32(); // unit id from characters.csv
                var amount = reader.ReadInt32();
                var level = reader.ReadInt32();
            }

            var count11 = reader.ReadInt32();
            for (int i = 0; i < count11; i++)
            {
                var id = reader.ReadInt32(); // mission id from missions.csv
            }

            var count12 = reader.ReadInt32();
            for (int i = 0; i < count12; i++)
            {
                var id = reader.ReadInt32(); // achievement id from achievements.csv
            }

            var count13 = reader.ReadInt32();
            for (int i = 0; i < count13; i++)
            {
                var id = reader.ReadInt32(); // achievement id from achievements.csv
                var progress = reader.ReadInt32();
            }

            var count14 = reader.ReadInt32();
            for (int i = 0; i < count14; i++)
            {
                var id = reader.ReadInt32(); // npc id from npcs.csv
                var stars = reader.ReadInt32();
            }

            var count15 = reader.ReadInt32();
            for (int i = 0; i < count15; i++)
            {
                var id = reader.ReadInt32(); // npc id from npcs.csv
                var gold = reader.ReadInt32();
            }

            var count16 = reader.ReadInt32();
            for (int i = 0; i < count16; i++)
            {
                var id = reader.ReadInt32(); // npc id from npcs.csv
                var elixir = reader.ReadInt32();
            }

            Unknown26 = reader.ReadInt32(); // troops donated?
            Unknown27 = reader.ReadInt32();
            Unknown28 = reader.ReadInt32();
        }

        public void WritePacket(PacketWriter writer)
        {
            writer.WriteInt32((int)LastVisit.TotalSeconds);
            writer.WriteInt32(Unknown1);
            writer.WriteInt32((int)DateTimeConverter.ToUnixTimestamp(DateTime.UtcNow));
            writer.WriteInt32(Unknown2);
            writer.WriteInt64(UserID);
            writer.WriteInt32((int)ShieldDuration.TotalSeconds);
            writer.WriteInt32(Unknown3);
            writer.WriteInt32(Unknown4);
            writer.WriteBoolean(Compressed);
            Home.Write(writer);
            writer.WriteInt32(Unknown6);
            writer.WriteInt64(UserID1);
            writer.WriteInt64(UserID2);
        }
    }
}
