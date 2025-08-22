// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

export interface Environment {
  production: boolean;
  baseUrl?: string | null;
  fallbackBaseUrl?: string | null;
  googleClientId: string | null;
  facebookClientId: string | null;
  microsoftClientId: string | null;
}
