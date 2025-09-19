export interface Environment {
  production: boolean;
  baseUrl?: string | null;
  fallbackBaseUrl?: string | null;
  googleClientId: string | null;
  facebookClientId: string | null;
  microsoftClientId: string | null;
}
