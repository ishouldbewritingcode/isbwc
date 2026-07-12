import { useQuery } from '@tanstack/react-query';
import { apiGet } from './client';
import type { NavItem, Site } from './types';

export function useSiteQuery() {
  return useQuery({
    queryKey: ['site'],
    queryFn: () => apiGet<Site>('/api/site'),
  });
}

export function useNavQuery() {
  return useQuery({
    queryKey: ['nav'],
    queryFn: () => apiGet<NavItem[]>('/api/nav'),
  });
}
