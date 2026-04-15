using System.IO;
using CalamityModCustomPublicPrivateFork.Systems;
using Terraria;
using Terraria.ID;

namespace CalamityModCustomPublicPrivateFork.Packets
{
    internal sealed class MusicEventSyncResponsePacket : CalamityPacket
    {
        public static MusicEventSyncResponsePacket Instance { get; private set; }

        public static void Send(int toClient = -1, int ignoreClient = -1)
        {
            // Only Server should send Reponse to Clients
            if (!Main.dedServ)
                return;

            var packet = Instance.CreateBasePacket();
            int trackCount = MusicEventSystem.PlayedEvents.Count;
            packet.Write(trackCount);

            foreach (string playedEvent in MusicEventSystem.PlayedEvents)
                packet.Write(playedEvent);

            packet.Send(toClient, ignoreClient);
        }

        public override void HandlePacket(BinaryReader packet, int sender)
        {
            // Only receive info as clients
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Still consume the packet anyways
                int c = packet.ReadInt32();
                for (int i = 0; i < c; i++)
                    _ = packet.ReadString();

                return;
            }

            MusicEventSystem.PlayedEvents.Clear();

            int trackCount = packet.ReadInt32();
            for (int i = 0; i < trackCount; i++)
                MusicEventSystem.PlayedEvents.Add(packet.ReadString());
        }
    }
}
