﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace UsbInfoTools
{
    #region Kernel32
    [SuppressUnmanagedCodeSecurity]
    internal static class Kernel32
    {
        /// <summary>
        /// 无效的文件句柄
        /// </summary>
        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        #region CreateFile
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(
            String fileName,
            [MarshalAs(UnmanagedType.U4)] NativeFileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] NativeFileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] NativeFileMode creationDisposition,
            NativeFileFlag flags,
            IntPtr template
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(
            String fileName,
            [MarshalAs(UnmanagedType.U4)] NativeFileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] NativeFileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] NativeFileMode creationDisposition,
            IntPtr flags,
            IntPtr template
            );
        #endregion

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean CloseHandle(IntPtr hFile);

        #region ReadFile
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(
            IntPtr hFile,
            [Out] Byte[] lpBuffer,
            Int32 nNumberOfBytesToRead,
            out Int32 lpNumberOfBytesRead,
            [In] ref System.Threading.NativeOverlapped lpOverlapped
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(
            IntPtr hFile,
            [Out] Byte[] lpBuffer,
            Int32 nNumberOfBytesToRead,
            IntPtr lpNumberOfBytesRead,
            [In] ref System.Threading.NativeOverlapped lpOverlapped
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(
            IntPtr hFile,
            [Out] Byte[] lpBuffer,
            Int32 nNumberOfBytesToRead,
            out Int32 lpNumberOfBytesRead,
            IntPtr lpOverlapped
            );
        #endregion

        #region WriteFile
        [DllImport("kernel32.dll")]
        public static extern Boolean WriteFile(
            IntPtr hFile,
            Byte[] lpBuffer,
            Int32 nNumberOfBytesToWrite,
            out Int32 lpNumberOfBytesWritten,
            [In] ref System.Threading.NativeOverlapped lpOverlapped
            );

        [DllImport("kernel32.dll")]
        public static extern Boolean WriteFile(
            IntPtr hFile,
            Byte[] lpBuffer,
            Int32 nNumberOfBytesToWrite,
            IntPtr lpNumberOfBytesWritten,
            [In] ref System.Threading.NativeOverlapped lpOverlapped
            );

        [DllImport("kernel32.dll")]
        public static extern Boolean WriteFile(
            IntPtr hFile,
            Byte[] lpBuffer,
            Int32 nNumberOfBytesToWrite,
            IntPtr lpNumberOfBytesWritten,
            IntPtr lpOverlapped
            );
        #endregion

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean GetOverlappedResult(
            IntPtr hFile,
            [In] ref System.Threading.NativeOverlapped lpOverlapped,
            out Int32 lpNumberOfBytesTransferred,
            Boolean bWait
            );        
    }
    #endregion

    #region ENUM
    [Flags]
    internal enum NativeFileAccess : uint
    {
        GENERIC_READ = (0x80000000),
        GENERIC_WRITE = (0x40000000),
        GENERIC_EXECUTE = (0x20000000),
        GENERIC_ALL = (0x10000000),

        FILE_SPECIAL = 0,
        FILE_APPEND_DATA = (0x0004),    // 文件
        FILE_READ_DATA = (0x0001),      // 文件和管道
        FILE_WRITE_DATA = (0x0002),     // 文件和管道
        FILE_READ_EA = (0x0008),        // 文件和目录
        FILE_WRITE_EA = (0x0010),       // 文件和目录
        FILE_READ_ATTRIBUTES = (0x0080),    // 所有
        FILE_WRITE_ATTRIBUTES = (0x0100),   // 所有
        DELETE = 0x00010000,
        READ_CONTROL = (0x00020000),
        WRITE_DAC = (0x00040000),
        WRITE_OWNER = (0x00080000),
        SYNCHRONIZE = (0x00100000),
        STANDARD_RIGHTS_REQUIRED = (0x000F0000),
        STANDARD_RIGHTS_READ = (READ_CONTROL),
        STANDARD_RIGHTS_WRITE = (READ_CONTROL),
        STANDARD_RIGHTS_EXECUTE = (READ_CONTROL),
        STANDARD_RIGHTS_ALL = (0x001F0000),
        SPECIFIC_RIGHTS_ALL = (0x0000FFFF),
        FILE_GENERIC_READ = (STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE),
        FILE_GENERIC_WRITE = (STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE),
        SPECIAL = 0
    }

    internal enum NativeFileMode : uint
    {
        CREATE_NEW = 1,
        CREATE_ALWAYS = 2,
        OPEN_EXISTING = 3,
        OPEN_ALWAYS = 4,
        TRUNCATE_EXISTING = 5,
    }

    [Flags]
    internal enum NativeFileShare : uint
    {
        NONE = 0,
        FILE_SHARE_READ = 0x00000001,
        FILE_SHARE_WRITE = 0x00000002,
        FILE_SHARE_DEELETE = 0x00000004,
    }

    [Flags]
    internal enum NativeFileFlag : uint
    {
        FILE_ATTRIBUTE_READONLY = 0x00000001,
        FILE_ATTRIBUTE_HIDDEN = 0x00000002,
        FILE_ATTRIBUTE_SYSTEM = 0x00000004,
        FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
        FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
        FILE_ATTRIBUTE_DEVICE = 0x00000040,
        FILE_ATTRIBUTE_NORMAL = 0x00000080,
        FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
        FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
        FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
        FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
        FILE_ATTRIBUTE_OFFLINE = 0x00001000,
        FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
        FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
        FILE_FLAG_WRITE_THROUGH = 0x80000000,
        FILE_FLAG_OVERLAPPED = 0x40000000,
        FILE_FLAG_NO_BUFFERING = 0x20000000,
        FILE_FLAG_RANDOM_ACCESS = 0x10000000,
        FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,
        FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,
        FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,
        FILE_FLAG_POSIX_SEMANTICS = 0x01000000,
        FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,
        FILE_FLAG_OPEN_NO_RECALL = 0x00100000,
        FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
    }
    #endregion
}
