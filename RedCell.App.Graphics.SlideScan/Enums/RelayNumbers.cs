using System;

namespace RedCell.Devices
{
    public enum Relaystate
    {
        OFF = 0x01,
        ON = 0x00
    }

    [Flags]
    public enum RelayNumbers : uint
    {
        Unknown = 0x0000,
        K01 = 0x0001,
        K02 = 0x0002,
        K03 = 0x0004,
        K04 = 0x0008,
        K05 = 0x0010,
        K06 = 0x0020,
        K07 = 0x0040,
        K08 = 0x0080,
        K09 = 0x0100,
        K10 = 0x0200,
        K11 = 0x0400,
        K12 = 0x0800,
        K13 = 0x1000,
        K14 = 0x2000,
        K15 = 0x4000,
        K16 = 0x8000,
        K17 = 0x10000,
        K18 = 0x20000,
        K19 = 0x40000,
        K20 = 0x80000,
        K21 = 0x100000,
        K22 = 0x200000,
        K23 = 0x400000,
        K24 = 0x800000,
        K25 = 0x1000000,
        K26 = 0x2000000,
        K27 = 0x4000000,
        K28 = 0x8000000,
        K29 = 0x10000000,
        K30 = 0x20000000,
        K31 = 0x40000000,
        K32 = 0x80000000,
        All = 0xffffffff
    }

}
