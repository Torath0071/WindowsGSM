using System.Collections.Generic;
using WindowsGSM.Functions;

namespace WindowsGSM.GameServer.Data
{
    static class Class
    {
        private static readonly Dictionary<string, dynamic> _serverCache = new Dictionary<string, dynamic>();

        public static dynamic Get(string serverGame, ServerConfig serverData = null, List<PluginMetadata> pluginList = null)
        {
            dynamic instance = null;

            if(serverData != null && _serverCache.TryGetValue(serverData.ServerID, out instance))
            {
                return instance;
            }

            switch (serverGame)
            {
                case CSGO.FullName: instance = new CSGO(serverData); break;
                case GMOD.FullName: instance = new GMOD(serverData); break;
                case TF2.FullName: instance = new TF2(serverData); break;
                case MCPE.FullName: instance = new MCPE(serverData); break;
                case RUST.FullName: instance = new RUST(serverData); break;
                case CS.FullName: instance = new CS(serverData); break;
                case CSCZ.FullName: instance = new CSCZ(serverData); break;
                case HL2DM.FullName: instance = new HL2DM(serverData); break;
                case L4D2.FullName: instance = new L4D2(serverData); break;
                case MC.FullName: instance = new MC(serverData); break;
                case GTA5.FullName: instance = new GTA5(serverData); break;
                case SDTD.FullName: instance = new SDTD(serverData); break;
                case MORDHAU.FullName: instance = new MORDHAU(serverData); break;
                case SE.FullName: instance = new SE(serverData); break;
                case DAYZ.FullName: instance = new DAYZ(serverData); break;
                case MCBE.FullName: instance = new MCBE(serverData); break;
                case OLOW.FullName: instance = new OLOW(serverData); break;
                case CSS.FullName: instance = new CSS(serverData); break;
                case INS.FullName: instance = new INS(serverData); break;
                case NMRIH.FullName: instance = new NMRIH(serverData); break;
                case ARKSE.FullName: instance = new ARKSE(serverData); break;
                case ZPS.FullName: instance = new ZPS(serverData); break;
                case DODS.FullName: instance = new DODS(serverData); break;
                case SW.FullName: instance = new SW(serverData); break;
                case ROK.FullName: instance = new ROK(serverData); break;
                case HEAT.FullName: instance = new HEAT(serverData); break;
                case BW.FullName: instance = new BW(serverData); break;
                case ONSET.FullName: instance = new ONSET(serverData); break;
                case EGS.FullName: instance = new EGS(serverData); break;
                case UNT.FullName: instance = new UNT(serverData); break; 
                case AVORION.FullName: instance = new AVORION(serverData); break;
                case CE.FullName: instance = new CE(serverData); break;
                case INSS.FullName: instance = new INSS(serverData); break;
                case DOD.FullName: instance = new DOD(serverData); break;
                case DMC.FullName: instance = new DMC(serverData); break;
                case HLOF.FullName: instance = new HLOF(serverData); break;
                case RCC.FullName: instance = new RCC(serverData); break;
                case TFC.FullName: instance = new TFC(serverData); break;
                case TF.FullName: instance = new TF(serverData); break;
                case SQ.FullName: instance = new SQ(serverData); break;
                case BT.FullName: instance = new BT(serverData); break;
                case PS.FullName: instance = new PS(serverData); break;
                case ROR2.FullName: instance = new ROR2(serverData); break;
                case ECO.FullName: instance = new ECO(serverData); break;
                case VTS.FullName: instance = new VTS(serverData); break;
                case SDK2013.FullName: instance = new SDK2013(serverData); break;
                default: // Load Plugin
                {
                    if (pluginList == null) { return null; }

                    foreach (var plugin in pluginList)
                    {
                        if (plugin.IsLoaded && plugin.FullName == serverGame)
                        {
                            instance = PluginManagement.GetPluginClass(plugin, serverData);
                            break;
                        }
                    }
                    break;
                };
            };

            if (instance != null)
            {
                _serverCache.Add(serverData.ServerID, instance);
            }

            return instance;
        }
    }
}
