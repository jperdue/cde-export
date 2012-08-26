﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public static class Ignore
	{
		public static bool Column(Row row, string column)
		{
			var level = row.Level;
			if (level == "A" && IgnoreA.Contains(column)) return true;
			if ((level == "E" || level == "M") && IgnoreEM.Contains(column)) return true;
			if (level == "H" && IgnoreH.Contains(column)) return true;
			return false;
		}

		static HashSet<string> ignoreA;
		static HashSet<string> ignoreEM;
		static HashSet<string> ignoreH;
		
		static HashSet<string> IgnoreA
		{
			get
			{
				if(ignoreA == null)
				{
					ignoreA = new HashSet<string>();
					A.ForEach(c => ignoreA.Add(c));
				}
				return ignoreA;
			}
		}

		static HashSet<string> IgnoreEM
		{
			get
			{
				if(ignoreEM == null)
				{
					ignoreEM = new HashSet<string>();
					EOrM.ForEach(c => ignoreEM.Add(c));
				}
				return ignoreEM;
			}
		}

		static HashSet<string> IgnoreH
		{
			get
			{
				if (ignoreH == null)
				{
					ignoreH = new HashSet<string>();
					H.ForEach(c => ignoreH.Add(c));
				}
				return ignoreH;
			}
		}

		static IEnumerable<string> H
		{
			get
			{
				yield return "RDPF_A_TTL_SPF_RATING_CALC";
				yield return "RDPF_A_TTL_SPF_RATING_OFFICIAL";
			}
		}

		static IEnumerable<string> A
		{
			get
			{
				yield return "RDPF_1YR_ACH_PTS_EARN_READ";
				yield return "RDPF_1YR_ACH_PTS_ELIG_READ";
				yield return "RDPF_1YR_ACH_RATING_REA";
				yield return "RDPF_1YR_ACH_N_COUNT_READ";
				yield return "RDPF_1YR_ACH_PA_PCT_REA";
				yield return "RDPF_1YR_ACH_PCTILE_READ";
				yield return "RDPF_1YR_ACH_PTS_EARN_MATH";
				yield return "RDPF_1YR_ACH_PTS_ELIG_MATH";
				yield return "RDPF_1YR_ACH_RATING_MATH";
				yield return "RDPF_1YR_ACH_N_COUNT_MATH";
				yield return "RDPF_1YR_ACH_PA_PCT_MATH";
				yield return "RDPF_1YR_ACH_PCTILE_MATH";
				yield return "RDPF_1YR_ACH_PTS_EARN_WRITE";
				yield return "RDPF_1YR_ACH_PTS_ELIG_WRITE";
				yield return "RDPF_1YR_ACH_RATING_WRITE";
				yield return "RDPF_1YR_ACH_N_COUNT_WRITE";
				yield return "RDPF_1YR_ACH_PA_PCT_WRITE";
				yield return "RDPF_1YR_ACH_PCTILE_WRITE";
				yield return "RDPF_1YR_ACH_PTS_EARN_SCI";
				yield return "RDPF_1YR_ACH_PTS_ELIG_SCI";
				yield return "RDPF_1YR_ACH_RATING_SCI";
				yield return "RDPF_1YR_ACH_N_COUNT_SC";
				yield return "RDPF_1YR_ACH_PA_PCT_SCI";
				yield return "RDPF_1YR_ACH_PCTILE_SCI";
				yield return "RDPF_1YR_ACH_PTS_EARN_TTL";
				yield return "RDPF_1YR_ACH_PTS_ELIG_TT";
				yield return "RDPF_1YR_ACH_PCT_PTS_EARN_TTL";
				yield return "RDPF_1YR_ACH_RATING_TT";
				yield return "RDPF_1YR_GRO_PTS_EARN_READ";
				yield return "RDPF_1YR_GRO_PTS_ELIG_READ";
				yield return "RDPF_1YR_GRO_RATING_READ";
				yield return "RDPF_1YR_GRO_N_COUNT_READ";
				yield return "RDPF_1YR_GRO_MGP_READ";
				yield return "RDPF_1YR_GRO_AGP_READ";
				yield return "RDPF_1YR_GRO_MADE_AGP_READ";
				yield return "RDPF_1YR_GRO_PTS_EARN_MATH";
				yield return "RDPF_1YR_GRO_PTS_ELIG_MATH";
				yield return "RDPF_1YR_GRO_RATING_MATH";
				yield return "RDPF_1YR_GRO_N_COUNT_MATH";
				yield return "RDPF_1YR_GRO_MGP_MATH";
				yield return "RDPF_1YR_GRO_AGP_MATH";
				yield return "RDPF_1YR_GRO_MADE_AGP_MATH";
				yield return "RDPF_1YR_GRO_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GRO_PTS_ELIG_WRITE";
				yield return "RDPF_1YR_GRO_RATING_WRITE";
				yield return "RDPF_1YR_GRO_N_COUNT_WRITE";
				yield return "RDPF_1YR_GRO_MGP_WRITE";
				yield return "RDPF_1YR_GRO_AGP_WRITE";
				yield return "RDPF_1YR_GRO_MADE_AGP_WRITE";
				yield return "RDPF_1YR_GRO_PTS_EARN_ELP";
				yield return "RDPF_1YR_GRO_PTS_ELIG_ELP";
				yield return "RDPF_1YR_GRO_RATING_EL";
				yield return "RDPF_1YR_GRO_N_COUNT_ELP";
				yield return "RDPF_1YR_GRO_MGP_ELP";
				yield return "RDPF_1YR_GRO_AGP_ELP";
				yield return "RDPF_1YR_GRO_MADE_AGP_ELP";
				yield return "RDPF_1YR_GRO_PTS_EARN_TTL";
				yield return "RDPF_1YR_GRO_PTS_ELIG_TTL";
				yield return "RDPF_1YR_GRO_PCT_PTS_EARN_TTL";
				yield return "RDPF_1YR_GRO_RATING_TT";
				yield return "RDPF_1YR_GG_FRL_PTS_EARN_READ";
				yield return "RDPF_1YR_GG_FRL_PTS_ELIG_REA";
				yield return "RDPF_1YR_GG_FRL_RATING_READ";
				yield return "RDPF_1YR_GG_FRL_N_COUNT_REA";
				yield return "RDPF_1YR_GG_FRL_MGP_READ";
				yield return "RDPF_1YR_GG_FRL_AGP_READ";
				yield return "RDPF_1YR_GG_FRL_MADE_AGP_READ";
				yield return "RDPF_1YR_GG_MIN_PTS_EARN_REA";
				yield return "RDPF_1YR_GG_MIN_PTS_ELIG_READ";
				yield return "RDPF_1YR_GG_MIN_RATING_READ";
				yield return "RDPF_1YR_GG_MIN_N_COUNT_READ";
				yield return "RDPF_1YR_GG_MIN_MGP_READ";
				yield return "RDPF_1YR_GG_MIN_AGP_READ";
				yield return "RDPF_1YR_GG_MIN_MADE_AGP_READ";
				yield return "RDPF_1YR_GG_DIS_PTS_EARN_READ";
				yield return "RDPF_1YR_GG_DIS_PTS_ELIG_REA";
				yield return "RDPF_1YR_GG_DIS_RATING_READ";
				yield return "RDPF_1YR_GG_DIS_N_COUNT_REA";
				yield return "RDPF_1YR_GG_DIS_MGP_READ";
				yield return "RDPF_1YR_GG_DIS_AGP_REA";
				yield return "RDPF_1YR_GG_DIS_MADE_AGP_READ";
				yield return "RDPF_1YR_GG_ELL_PTS_EARN_REA";
				yield return "RDPF_1YR_GG_ELL_PTS_ELIG_READ";
				yield return "RDPF_1YR_GG_ELL_RATING_READ";
				yield return "RDPF_1YR_GG_ELL_N_COUNT_READ";
				yield return "RDPF_1YR_GG_ELL_MGP_READ";
				yield return "RDPF_1YR_GG_ELL_AGP_READ";
				yield return "RDPF_1YR_GG_ELL_MADE_AGP_READ";
				yield return "RDPF_1YR_GG_BPA_PTS_EARN_READ";
				yield return "RDPF_1YR_GG_BPA_PTS_ELIG_REA";
				yield return "RDPF_1YR_GG_BPA_RATING_READ";
				yield return "RDPF_1YR_GG_BPA_N_COUNT_REA";
				yield return "RDPF_1YR_GG_BPA_MGP_READ";
				yield return "RDPF_1YR_GG_BPA_AGP_READ";
				yield return "RDPF_1YR_GG_BPA_MADE_AGP_READ";
				yield return "RDPF_1YR_GG_PTS_EARN_READ";
				yield return "RDPF_1YR_GG_PTS_ELIG_READ";
				yield return "RDPF_1YR_GG_PCT_PTS_EARN_READ";
				yield return "RDPF_1YR_GG_RATING_READ";
				yield return "RDPF_1YR_GG_FRL_PTS_EARN_MATH";
				yield return "RDPF_1YR_GG_FRL_PTS_ELIG_MATH";
				yield return "RDPF_1YR_GG_FRL_RATING_MATH";
				yield return "RDPF_1YR_GG_FRL_N_COUNT_MATH";
				yield return "RDPF_1YR_GG_FRL_MGP_MATH";
				yield return "RDPF_1YR_GG_FRL_AGP_MATH";
				yield return "RDPF_1YR_GG_FRL_MADE_AGP_MATH";
				yield return "RDPF_1YR_GG_MIN_PTS_EARN_MATH";
				yield return "RDPF_1YR_GG_MIN_PTS_ELIG_MAT";
				yield return "RDPF_1YR_GG_MIN_RATING_MATH";
				yield return "RDPF_1YR_GG_MIN_N_COUNT_MAT";
				yield return "RDPF_1YR_GG_MIN_MGP_MATH";
				yield return "RDPF_1YR_GG_MIN_AGP_MATH";
				yield return "RDPF_1YR_GG_MIN_MADE_AGP_MATH";
				yield return "RDPF_1YR_GG_DIS_PTS_EARN_MAT";
				yield return "RDPF_1YR_GG_DIS_PTS_ELIG_MATH";
				yield return "RDPF_1YR_GG_DIS_RATING_MATH";
				yield return "RDPF_1YR_GG_DIS_N_COUNT_MATH";
				yield return "RDPF_1YR_GG_DIS_MGP_MATH";
				yield return "RDPF_1YR_GG_DIS_AGP_MATH";
				yield return "RDPF_1YR_GG_DIS_MADE_AGP_MATH";
				yield return "RDPF_1YR_GG_ELL_PTS_EARN_MATH";
				yield return "RDPF_1YR_GG_ELL_PTS_ELIG_MAT";
				yield return "RDPF_1YR_GG_ELL_RATING_MATH";
				yield return "RDPF_1YR_GG_ELL_N_COUNT_MAT";
				yield return "RDPF_1YR_GG_ELL_MGP_MATH";
				yield return "RDPF_1YR_GG_ELL_AGP_MATH";
				yield return "RDPF_1YR_GG_ELL_MADE_AGP_MATH";
				yield return "RDPF_1YR_GG_BPA_PTS_EARN_MATH";
				yield return "RDPF_1YR_GG_BPA_PTS_ELIG_MATH";
				yield return "RDPF_1YR_GG_BPA_RATING_MATH";
				yield return "RDPF_1YR_GG_BPA_N_COUNT_MATH";
				yield return "RDPF_1YR_GG_BPA_MGP_MATH";
				yield return "RDPF_1YR_GG_BPA_AGP_MATH";
				yield return "RDPF_1YR_GG_BPA_MADE_AGP_MATH";
				yield return "RDPF_1YR_GG_PTS_EARN_MATH";
				yield return "RDPF_1YR_GG_PTS_ELIG_MATH";
				yield return "RDPF_1YR_GG_PCT_PTS_EARN_MATH";
				yield return "RDPF_1YR_GG_RATING_MAT";
				yield return "RDPF_1YR_GG_FRL_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_FRL_PTS_ELIG_WRIT";
				yield return "RDPF_1YR_GG_FRL_RATING_WRITE";
				yield return "RDPF_1YR_GG_FRL_N_COUNT_WRIT";
				yield return "RDPF_1YR_GG_FRL_MGP_WRITE";
				yield return "RDPF_1YR_GG_FRL_AGP_WRITE";
				yield return "RDPF_1YR_GG_FRL_MADE_AGP_WRITE";
				yield return "RDPF_1YR_GG_MIN_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_MIN_PTS_ELIG_WRITE";
				yield return "RDPF_1YR_GG_MIN_RATING_WRITE";
				yield return "RDPF_1YR_GG_MIN_N_COUNT_WRITE";
				yield return "RDPF_1YR_GG_MIN_MGP_WRITE";
				yield return "RDPF_1YR_GG_MIN_AGP_WRITE";
				yield return "RDPF_1YR_GG_MIN_MADE_AGP_WRITE";
				yield return "RDPF_1YR_GG_DIS_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_DIS_PTS_ELIG_WRIT";
				yield return "RDPF_1YR_GG_DIS_RATING_WRITE";
				yield return "RDPF_1YR_GG_DIS_N_COUNT_WRIT";
				yield return "RDPF_1YR_GG_DIS_MGP_WRITE";
				yield return "RDPF_1YR_GG_DIS_AGP_WRITE";
				yield return "RDPF_1YR_GG_DIS_MADE_AGP_WRITE";
				yield return "RDPF_1YR_GG_ELL_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_ELL_PTS_ELIG_WRITE";
				yield return "RDPF_1YR_GG_ELL_RATING_WRITE";
				yield return "RDPF_1YR_GG_ELL_N_COUNT_WRITE";
				yield return "RDPF_1YR_GG_ELL_MGP_WRITE";
				yield return "RDPF_1YR_GG_ELL_AGP_WRITE";
				yield return "RDPF_1YR_GG_ELL_MADE_AGP_WRITE";
				yield return "RDPF_1YR_GG_BPA_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_BPA_PTS_ELIG_WRITE";
				yield return "RDPF_1YR_GG_BPA_RATING_WRITE";
				yield return "RDPF_1YR_GG_BPA_N_COUNT_WRITE";
				yield return "RDPF_1YR_GG_BPA_MGP_WRITE";
				yield return "RDPF_1YR_GG_BPA_AGP_WRITE";
				yield return "RDPF_1YR_GG_BPA_MADE_AGP_WRITE";
				yield return "RDPF_1YR_GG_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_PTS_ELIG_WRITE";
				yield return "RDPF_1YR_GG_PCT_PTS_EARN_WRITE";
				yield return "RDPF_1YR_GG_RATING_WRITE";
				yield return "RDPF_1YR_GG_PTS_EARN_TT";
				yield return "RDPF_1YR_GG_PTS_ELIG_TTL";
				yield return "RDPF_1YR_GG_PCT_PTS_EARN_TT";
				yield return "RDPF_1YR_GG_RATING_TTL";
				yield return "RDPF_1YR_PS_GRAD_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_RATIN";
				yield return "RDPF_1YR_PS_GRAD_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_DN_4Y";
				yield return "RDPF_1YR_PS_GRAD_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_DN_6Y";
				yield return "RDPF_1YR_PS_GRAD_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_GR_4Y";
				yield return "RDPF_1YR_PS_GRAD_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_GR_6Y";
				yield return "RDPF_1YR_PS_GRAD_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_FRL_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_FRL_PTS_ELI";
				yield return "RDPF_1YR_PS_GRAD_FRL_RATING";
				yield return "RDPF_1YR_PS_GRAD_FRL_BEST_D";
				yield return "RDPF_1YR_PS_GRAD_FRL_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_FRL_BEST_Y";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_MIN_PTS_EAR";
				yield return "RDPF_1YR_PS_GRAD_MIN_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_MIN_RATING";
				yield return "RDPF_1YR_PS_GRAD_MIN_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_MIN_BEST_G";
				yield return "RDPF_1YR_PS_GRAD_MIN_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_IEP_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_IEP_PTS_ELI";
				yield return "RDPF_1YR_PS_GRAD_IEP_RATING";
				yield return "RDPF_1YR_PS_GRAD_IEP_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_IEP_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_IEP_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_ELL_PTS_EAR";
				yield return "RDPF_1YR_PS_GRAD_ELL_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_ELL_RATING";
				yield return "RDPF_1YR_PS_GRAD_ELL_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_ELL_BEST_G";
				yield return "RDPF_1YR_PS_GRAD_ELL_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_DSAG_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_DSAG_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_DSAG_PCT_PTS";
				yield return "RDPF_1YR_PS_GRAD_DSAG_RATIN";
				yield return "RDPF_1YR_PS_DROP_PTS_EARN";
				yield return "RDPF_1YR_PS_DROP_PTS_ELIG";
				yield return "RDPF_1YR_PS_DROP_RATING";
				yield return "RDPF_1YR_PS_DROP_N_COUNT";
				yield return "RDPF_1YR_PS_DROP_RATE";
				yield return "RDPF_1YR_PS_DROP_STATE_EXP";
				yield return "RDPF_1YR_PS_ACT_PTS_EARN";
				yield return "RDPF_1YR_PS_ACT_PTS_ELI";
				yield return "RDPF_1YR_PS_ACT_RATING";
				yield return "RDPF_1YR_PS_ACT_N_COUN";
				yield return "RDPF_1YR_PS_ACT_SCORE";
				yield return "RDPF_1YR_PS_ACT_STATE_EXP";
				yield return "RDPF_1YR_PS_PTS_EARN_TTL";
				yield return "RDPF_1YR_PS_PTS_ELIG_TT";
				yield return "RDPF_1YR_PS_PCT_PTS_EARN_TTL";
				yield return "RDPF_1YR_PS_RATING_TTL";
				yield return "RDPF_A_TTL_SPF_RATING_CALC";
				yield return "RDPF_A_TTL_SPF_RATING_OFFICIAL";
			}
		}

		static IEnumerable<String> EOrM
		{
			get
			{
				yield return "RDPF_1_3_POST_SEC_RATING";
				yield return "RDPF_1_3_POST_SEC_PCT_PTS_EARN";
				yield return "RDPF_1YR_POST_SEC_RATING";
				yield return "RDPF_1YR_POST_SEC_PCT_PTS_EARN";
				yield return "RDPF_3YR_POST_SEC_RATING";
				yield return "RDPF_3YR_POST_SEC_PCT_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_RATING";
				yield return "RDPF_1YR_PS_GRAD_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_FRL_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_FRL_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_FRL_RATING";
				yield return "RDPF_1YR_PS_GRAD_FRL_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_FRL_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_FRL_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_FRL_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_MIN_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_MIN_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_MIN_RATING";
				yield return "RDPF_1YR_PS_GRAD_MIN_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_MIN_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_MIN_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_MIN_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_IEP_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_IEP_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_IEP_RATING";
				yield return "RDPF_1YR_PS_GRAD_IEP_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_IEP_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_IEP_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_IEP_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_ELL_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_ELL_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_ELL_RATING";
				yield return "RDPF_1YR_PS_GRAD_ELL_BEST_DN";
				yield return "RDPF_1YR_PS_GRAD_ELL_BEST_GR";
				yield return "RDPF_1YR_PS_GRAD_ELL_BEST_YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_4YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_5YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_6YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_DN_7YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_4YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_5YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_6YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_GR_7YR";
				yield return "RDPF_1YR_PS_GRAD_ELL_STATE_EXP";
				yield return "RDPF_1YR_PS_GRAD_DSAG_PTS_EARN";
				yield return "RDPF_1YR_PS_GRAD_DSAG_PTS_ELIG";
				yield return "RDPF_1YR_PS_GRAD_DSAG_PCT_PTS";
				yield return "RDPF_1YR_PS_GRAD_DSAG_RATING";
				yield return "RDPF_1YR_PS_DROP_PTS_EARN";
				yield return "RDPF_1YR_PS_DROP_PTS_ELIG";
				yield return "RDPF_1YR_PS_DROP_RATING";
				yield return "RDPF_1YR_PS_DROP_N_COUNT";
				yield return "RDPF_1YR_PS_DROP_RATE";
				yield return "RDPF_1YR_PS_DROP_STATE_EXP";
				yield return "RDPF_1YR_PS_ACT_PTS_EARN";
				yield return "RDPF_1YR_PS_ACT_PTS_ELIG";
				yield return "RDPF_1YR_PS_ACT_RATING";
				yield return "RDPF_1YR_PS_ACT_N_COUNT";
				yield return "RDPF_1YR_PS_ACT_SCORE";
				yield return "RDPF_1YR_PS_ACT_STATE_EXP";
				yield return "RDPF_1YR_PS_PTS_EARN_TTL";
				yield return "RDPF_1YR_PS_PTS_ELIG_TTL";
				yield return "RDPF_1YR_PS_PCT_PTS_EARN_TTL";
				yield return "RDPF_1YR_PS_RATING_TTL";
				yield return "RDPF_1YR_PARTIC_PCT_TEST_ACT";
				yield return "RDPF_1YR_PARTIC_RATING_ACT";
				yield return "RDPF_1YR_PARTIC_NM_ACT";
				yield return "RDPF_1YR_PARTIC_DN_ACT";
				yield return "RDPF_3YR_PS_GRAD_PTS_EARN";
				yield return "RDPF_3YR_PS_GRAD_PTS_ELIG";
				yield return "RDPF_3YR_PS_GRAD_RATING";
				yield return "RDPF_3YR_PS_GRAD_BEST_DN";
				yield return "RDPF_3YR_PS_GRAD_BEST_GR";
				yield return "RDPF_3YR_PS_GRAD_BEST_YR";
				yield return "RDPF_3YR_PS_GRAD_DN_4YR";
				yield return "RDPF_3YR_PS_GRAD_DN_5YR";
				yield return "RDPF_3YR_PS_GRAD_DN_6YR";
				yield return "RDPF_3YR_PS_GRAD_DN_7YR";
				yield return "RDPF_3YR_PS_GRAD_GR_4YR";
				yield return "RDPF_3YR_PS_GRAD_GR_5YR";
				yield return "RDPF_3YR_PS_GRAD_GR_6YR";
				yield return "RDPF_3YR_PS_GRAD_GR_7YR";
				yield return "RDPF_3YR_PS_GRAD_STATE_EXP";
				yield return "RDPF_3YR_PS_GRAD_FRL_PTS_EARN";
				yield return "RDPF_3YR_PS_GRAD_FRL_PTS_ELIG";
				yield return "RDPF_3YR_PS_GRAD_FRL_RATING";
				yield return "RDPF_3YR_PS_GRAD_FRL_BEST_DN";
				yield return "RDPF_3YR_PS_GRAD_FRL_BEST_GR";
				yield return "RDPF_3YR_PS_GRAD_FRL_BEST_YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_DN_4YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_DN_5YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_DN_6YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_DN_7YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_GR_4YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_GR_5YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_GR_6YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_GR_7YR";
				yield return "RDPF_3YR_PS_GRAD_FRL_STATE_EXP";
				yield return "RDPF_3YR_PS_GRAD_MIN_PTS_EARN";
				yield return "RDPF_3YR_PS_GRAD_MIN_PTS_ELIG";
				yield return "RDPF_3YR_PS_GRAD_MIN_RATING";
				yield return "RDPF_3YR_PS_GRAD_MIN_BEST_DN";
				yield return "RDPF_3YR_PS_GRAD_MIN_BEST_GR";
				yield return "RDPF_3YR_PS_GRAD_MIN_BEST_YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_DN_4YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_DN_5YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_DN_6YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_DN_7YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_GR_4YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_GR_5YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_GR_6YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_GR_7YR";
				yield return "RDPF_3YR_PS_GRAD_MIN_STATE_EXP";
				yield return "RDPF_3YR_PS_GRAD_IEP_PTS_EARN";
				yield return "RDPF_3YR_PS_GRAD_IEP_PTS_ELIG";
				yield return "RDPF_3YR_PS_GRAD_IEP_RATING";
				yield return "RDPF_3YR_PS_GRAD_IEP_BEST_DN";
				yield return "RDPF_3YR_PS_GRAD_IEP_BEST_GR";
				yield return "RDPF_3YR_PS_GRAD_IEP_BEST_YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_DN_4YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_DN_5YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_DN_6YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_DN_7YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_GR_4YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_GR_5YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_GR_6YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_GR_7YR";
				yield return "RDPF_3YR_PS_GRAD_IEP_STATE_EXP";
				yield return "RDPF_3YR_PS_GRAD_ELL_PTS_EARN";
				yield return "RDPF_3YR_PS_GRAD_ELL_PTS_ELIG";
				yield return "RDPF_3YR_PS_GRAD_ELL_RATING";
				yield return "RDPF_3YR_PS_GRAD_ELL_BEST_DN";
				yield return "RDPF_3YR_PS_GRAD_ELL_BEST_GR";
				yield return "RDPF_3YR_PS_GRAD_ELL_BEST_YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_DN_4YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_DN_5YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_DN_6YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_DN_7YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_GR_4YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_GR_5YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_GR_6YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_GR_7YR";
				yield return "RDPF_3YR_PS_GRAD_ELL_STATE_EXP";
				yield return "RDPF_3YR_PS_GRAD_DSAG_PTS_EARN";
				yield return "RDPF_3YR_PS_GRAD_DSAG_PTS_ELIG";
				yield return "RDPF_3YR_PS_GRAD_DSAG_PCT_PTS";
				yield return "RDPF_3YR_PS_GRAD_DSAG_RATING";
				yield return "RDPF_3YR_PS_DROP_PTS_EARN";
				yield return "RDPF_3YR_PS_DROP_PTS_ELIG";
				yield return "RDPF_3YR_PS_DROP_RATING";
				yield return "RDPF_3YR_PS_DROP_N_COUNT";
				yield return "RDPF_3YR_PS_DROP_RATE";
				yield return "RDPF_3YR_PS_DROP_STATE_EXP";
				yield return "RDPF_3YR_PS_ACT_PTS_EARN";
				yield return "RDPF_3YR_PS_ACT_PTS_ELIG";
				yield return "RDPF_3YR_PS_ACT_RATING";
				yield return "RDPF_3YR_PS_ACT_N_COUNT";
				yield return "RDPF_3YR_PS_ACT_SCORE";
				yield return "RDPF_3YR_PS_ACT_STATE_EXPRDPF_3YR_PS_PTS_EARN_TTL";
				yield return "RDPF_3YR_PS_PTS_ELIG_TTL";
				yield return "RDPF_3YR_PS_PCT_PTS_EARN_TTL";
				yield return "RDPF_3YR_PS_RATING_TTL";
				yield return "RDPF_3YR_PARTIC_PCT_TEST_ACT";
				yield return "RDPF_3YR_PARTIC_RATING_ACT";
				yield return "RDPF_3YR_PARTIC_NM_ACT";
				yield return "RDPF_3YR_PARTIC_DN_ACT";
				yield return "RDPF_A_TTL_DPF_RATING_OFFICIAL";
				yield return "RDPF_A_TTL_SPF_RATING_CALC";
				yield return "RDPF_A_TTL_SPF_RATING_OFFICIAL";		
			}
		}
	}
}