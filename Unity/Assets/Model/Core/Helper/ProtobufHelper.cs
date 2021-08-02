using System;
using System.IO;
#if !NOT_UNITY
using ETCold;
#endif
using ProtoBuf;

namespace ET
{
    public static class ProtobufHelper
    {
        static ProtobufHelper()
        {

        }

        public static void Init()
        {


#if !NOT_UNITY
            var types = Game.EventSystem.GetAllType();

            foreach (Type type in types)
            {
                //Log.Info($"typename :{type} ");
                if (type.GetCustomAttributes(typeof(ProtoContractAttribute), false).Length == 0 && type.GetCustomAttributes(typeof(ProtoMemberAttribute), false).Length == 0)
                {
                    continue;
                }
                //if (!type.IsSubclassOf(typeof(ProtoObject)))
                //{
                //    continue;
                //}
                //Log.Info($"注册 ;{type.FullName }");
                PBType.RegisterType(type.FullName, type);
            }
#endif
        }

        public static object FromBytes(Type type, byte[] bytes, int index, int count)
        {
            using (MemoryStream stream = new MemoryStream(bytes, index, count))
            {
                return ProtoBuf.Serializer.Deserialize(type, stream);
            }
        }

        public static byte[] ToBytes(object message)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, message);
                return stream.ToArray();
            }
        }

        public static void ToStream(object message, MemoryStream stream)
        {
            ProtoBuf.Serializer.Serialize(stream, message);
        }

        public static object FromStream(Type type, MemoryStream stream)
        {
            return ProtoBuf.Serializer.Deserialize(type, stream);
        }
    }
}