// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

namespace Torgay.Core.Extensions
{
    public static class ArrayExtensions
    {
        public static T[]? NullIfEmpty<T>(this T[]? value) => value?.Length == 0 ? null : value;

        public static T[]? EmptyIfNull<T>(this T[]? value) => value ?? [];
    }
}
