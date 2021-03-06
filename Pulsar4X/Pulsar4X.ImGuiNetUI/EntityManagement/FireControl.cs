using System;
using System.Collections.Generic;
using System.Linq;
using ImGuiNET;
using Pulsar4X.ECSLib;
using Pulsar4X.ECSLib.ComponentFeatureSets.Missiles;
using Pulsar4X.ECSLib.ComponentFeatureSets.RailGun;
using Pulsar4X.SDL2UI;

namespace Pulsar4X.ImGuiNetUI
{
    public class FireControl : PulsarGuiWindow
    {
        private EntityState _orderEntityState;
        private Entity _orderEntity { get { return _orderEntityState.Entity; } }
        
        //string[] _allWeaponNames = new string[0];
        //ComponentDesign[] _allWeaponDesigns = new ComponentDesign[0];
        //ComponentInstance[] _allWeaponInstances = new ComponentInstance[0];
        ComponentInstance[] _missileLaunchers = new ComponentInstance[0];
        WeaponState[] _mlstates = new WeaponState[0];
        ComponentInstance[] _railGuns = new ComponentInstance[0];
        WeaponState[] _rgstates = new WeaponState[0];
        WeaponState[] _beamstates = new WeaponState[0];
        ComponentInstance[] _beamWpns = new ComponentInstance[0];
        
        
        SensorContact[] _allSensorContacts = new SensorContact[0];
        string[] _ownEntityNames = new string[0];
        EntityState[] _ownEntites = new EntityState[0];
        
        
        ComponentInstance[] _allFireControl = new ComponentInstance[0];
        FireControlAbilityState[] _fcState = new FireControlAbilityState[0];
        int[][] _assignedWeapons = new int[0][];

        string[] _fcTarget = new string[0];
        
        private FireControl()
        {
            
        }



        public static FireControl GetInstance(EntityState orderEntity)
        {
            FireControl thisitem;
            if (!_uiState.LoadedWindows.ContainsKey(typeof(FireControl)))
            {
                thisitem = new FireControl();
                thisitem.HardRefresh(orderEntity);
            }
            else
            {
                thisitem = (FireControl)_uiState.LoadedWindows[typeof(FireControl)];
                if(thisitem._orderEntityState != orderEntity)
                    thisitem.HardRefresh(orderEntity);
            }
            
            return thisitem;
        }
        

        public override void OnSystemTickChange(DateTime newdate)
        {
            
            for (int i = 0; i < _allFireControl.Length; i++)
            {
                _fcTarget[i] = "None";
                if (_allFireControl[i].TryGetAbilityState(out FireControlAbilityState fcstate))
                {
                    _fcState[i] = fcstate;
                    if (fcstate.Target != null)
                    {
                        _fcTarget[i] = fcstate.Target.GetDataBlob<NameDB>().GetName(_orderEntity.FactionOwner);
                    }
                }
            }
        }
        
        void HardRefresh(EntityState orderEntity)
        {
            _orderEntityState = orderEntity;
            if(orderEntity.DataBlobs.ContainsKey(typeof(FireControlAbilityDB)))
            {
                var instancesDB = orderEntity.Entity.GetDataBlob<ComponentInstancesDB>();
            
                if( instancesDB.TryGetComponentsByAttribute<BeamFireControlAtbDB>(out var fcinstances))
                {
                    _allFireControl = new ComponentInstance[fcinstances.Count];
                    _fcTarget = new string[fcinstances.Count]; 
                    _fcState = new FireControlAbilityState[fcinstances.Count];
                    for (int i = 0; i < fcinstances.Count; i++)
                    {
                        _allFireControl[i] = fcinstances[i];
                        _fcTarget[i] = "None";
                        if (fcinstances[i].TryGetAbilityState(out FireControlAbilityState fcstate))
                        {
                            _fcState[i] = fcstate;
                            if (fcstate.Target != null)
                            {
                                _fcTarget[i] = fcstate.Target.GetDataBlob<NameDB>().GetName(orderEntity.Entity.FactionOwner);
                            }
                        }
                    }
                }

                
                if (instancesDB.TryGetComponentsByAttribute<MissileLauncherAtb>(out var mlinstances))
                {
                    _missileLaunchers = mlinstances.ToArray();
                    _mlstates = new WeaponState[mlinstances.Count];
                    for (int i = 0; i < mlinstances.Count; i++)
                    {
                        _mlstates[i] = mlinstances[i].GetAbilityState<WeaponState>();
                    }
                    
                }
                if (instancesDB.TryGetComponentsByAttribute<RailGunAtb>(out var railGuns))
                {
                    _railGuns = railGuns.ToArray();
                    _rgstates = new WeaponState[railGuns.Count];
                    for (int i = 0; i < railGuns.Count; i++)
                    {
                        _rgstates[i] = railGuns[i].GetAbilityState<WeaponState>();
                    }
                }

                if (instancesDB.TryGetComponentsByAttribute<SimpleBeamWeaponAtbDB>(out var beams))
                {
                    _beamWpns = beams.ToArray();
                    _beamstates = new WeaponState[beams.Count];
                    for (int i = 0; i < beams.Count; i++)
                    {
                        _beamstates[i] = beams[i].GetAbilityState<WeaponState>();
                    }
                }
            }
            
            var sysstate = _uiState.StarSystemStates[_uiState.SelectedStarSysGuid];

            var contacts = sysstate.SystemContacts;
            _allSensorContacts = contacts.GetAllContacts().ToArray();
            _ownEntites = sysstate.EntityStatesWithPosition.Values.ToArray();
        }

        void OnFrameRefresh()
        {
            for (int i = 0; i < _allFireControl.Length; i++)
            {
                string tgt = "None";
                if (_allFireControl[i].TryGetAbilityState(out FireControlAbilityState fcstate))
                {
                    _fcState[i] = fcstate;
                    if (fcstate.Target != null)
                    {
                        tgt = fcstate.Target.GetDataBlob<NameDB>().GetName(_orderEntity.FactionOwner);
                    }
                }
                _fcTarget[i] = tgt;
                
            }
        }

        void SetWeapons(Guid[] wpnsAssignd)
        {
            SetWeaponsFireControlOrder.CreateCommand(_uiState.Game, _uiState.PrimarySystemDateTime, _uiState.Faction.Guid, _orderEntity.Guid, _allFireControl[_fcIndex].ID, wpnsAssignd);
        }

        void SetTarget(Guid targetID)
        {
            SetTargetFireControlOrder.CreateCommand(_uiState.Game, _uiState.PrimarySystemDateTime, _uiState.Faction.Guid, _orderEntity.Guid, _allFireControl[_fcIndex].ID, targetID);
        }
        
        private void OpenFire(Guid fcID, SetOpenFireControlOrder.FireModes mode)
        {
            SetOpenFireControlOrder.CreateCmd(_uiState.Game, _uiState.Faction, _orderEntity, fcID, mode);
        }

        internal override void Display()
        {
            if (!IsActive)
                return;
            OnFrameRefresh();
            if (ImGui.Begin("Fire Control"))
            {
                ImGui.Columns(2);
                DisplayFC();
                ImGui.NextColumn();
                Display2ndColomn();
            }
        }

        void DisplayFC()
        {
            for (int i = 0; i < _allFireControl.Length; i++)
            {
                BorderGroup.BeginBorder(_allFireControl[i].Name);
                
                ImGui.Text("Target: " + _fcTarget[i]);
                ImGui.SameLine();
                if (ImGui.SmallButton("Set New"))
                {
                    _fcIndex = i;
                    _c2type = C2Type.SetTarget;
                }
                if (_fcState[i].IsEngaging)
                {
                    if (ImGui.Button("Cease Fire"))
                        OpenFire(_allFireControl[i].ID, SetOpenFireControlOrder.FireModes.CeaseFire);
                }
                else
                {
                    if (ImGui.Button("Open Fire"))
                        OpenFire(_allFireControl[i].ID, SetOpenFireControlOrder.FireModes.OpenFire);
                }

                var wns = new List<ComponentInstance>( _fcState[i].AssignedWeapons);
                for (int j = 0; j < wns.Count; j++)
                {
                    var wpn = wns[j];
                    if (ImGui.SmallButton(wpn.Name))
                    {
                        
                        wns.RemoveAt(j);
                        Guid[] wnids = new Guid[wns.Count];
                        for (int k = 0; k < wns.Count; k++)
                        {
                            wnids[k] = wns[k].ID;
                        }
                        SetWeapons(wnids);
                    }

                }

                if (ImGui.Button("Assign Weapons"))
                {
                    _fcIndex = i;
                    _c2type = C2Type.SetWeapons;
                }

                BorderGroup.EndBoarder();
                
            }
            
        }

        enum C2Type
        {
            Nill,
            SetTarget,
            SetWeapons,
        }
        private int _fcIndex;
        private C2Type _c2type;
        private bool _showOwnAsTarget;
        void Display2ndColomn()
        {
            if (_c2type == C2Type.Nill)
                return;
            if (_c2type == C2Type.SetTarget)
            {
                BorderGroup.BeginBorder("Set Target:");
                ImGui.Checkbox("Show Own", ref _showOwnAsTarget);

                for (int i = 0; i < _allSensorContacts.Length; i++)
                {
                    var contact = _allSensorContacts[i];
                    if (ImGui.SmallButton("Set ##sens" + i ))
                    {
                        SetTarget(contact.ActualEntityGuid);
                    }

                    ImGui.SameLine();
                    ImGui.Text(contact.Name);
                }

                if (_showOwnAsTarget)
                {
                    for (int i = 0; i < _ownEntites.Length; i++)
                    {
                        var contact = _ownEntites[i];
                        if(ImGui.SmallButton("Set##own" + i ))
                        {
                            SetTarget(contact.Entity.Guid);
                        }
                        ImGui.SameLine();
                        ImGui.Text(contact.Name);
                    }
                }
                BorderGroup.EndBoarder();
            }

            if (_c2type == C2Type.SetWeapons)
            {
                BorderGroup.BeginBorder("Missile Launchers:");
                for (int i = 0; i < _missileLaunchers.Length; i++)
                {
                    if( ImGui.SmallButton(_missileLaunchers[i].Name + "##" + i))
                    {
                        var wns = new List<ComponentInstance>( _fcState[i].AssignedWeapons);
                        Guid[] wnids = new Guid[wns.Count + 1];
                        for (int k = 0; k < wns.Count; k++)
                        {
                            wnids[k] = wns[k].ID;
                        }
                        wnids[wns.Count] = _missileLaunchers[i].ID;
                        SetWeapons(wnids);
                    }
                    ImGui.Indent();
                    for (int j = 0; j < _mlstates[i].WeaponStats.Length; j++)
                    {
                        var stat = _mlstates[i].WeaponStats[j];
                        string str = stat.name + Stringify.Value(stat.value, stat.valueType);
                        ImGui.Text(str);
                    }
                    ImGui.Unindent();
                    
                }
                BorderGroup.EndBoarder();
                ImGui.NewLine();
                BorderGroup.BeginBorder("Rail Guns:");
                for (int i = 0; i < _railGuns.Length; i++)
                {
                    
                    if( ImGui.SmallButton(_railGuns[i].Name + "##" + i))
                    {
                        var wns = new List<ComponentInstance>( _fcState[i].AssignedWeapons);
                        Guid[] wnids = new Guid[wns.Count + 1];
                        for (int k = 0; k < wns.Count; k++)
                        {
                            wnids[k] = wns[k].ID;
                        }
                        wnids[wns.Count] = _railGuns[i].ID;
                        SetWeapons(wnids);
                    }
                    ImGui.Indent();
                    for (int j = 0; j < _rgstates[i].WeaponStats.Length; j++)
                    {
                        var stat = _rgstates[i].WeaponStats[j];
                        string str = stat.name + Stringify.Value(stat.value, stat.valueType);
                        ImGui.Text(str);
                    }
                    ImGui.Unindent();
                    
                }
                BorderGroup.EndBoarder();
                ImGui.NewLine();
                BorderGroup.BeginBorder("Beam Weapons:");
                for (int i = 0; i < _beamWpns.Length; i++)
                {
                    if( ImGui.SmallButton(_beamWpns[i].Name + "##" + i))
                    {
                        var wns = new List<ComponentInstance>( _fcState[i].AssignedWeapons);
                        Guid[] wnids = new Guid[wns.Count + 1];
                        for (int k = 0; k < wns.Count; k++)
                        {
                            wnids[k] = wns[k].ID;
                        }
                        wnids[wns.Count] = _beamWpns[i].ID;
                        SetWeapons(wnids);
                    }
                    ImGui.Indent();
                    for (int j = 0; j < _beamstates[i].WeaponStats.Length; j++)
                    {
                        var stat = _beamstates[i].WeaponStats[j];
                        string str = stat.name + Stringify.Value(stat.value, stat.valueType);
                        ImGui.Text(str);
                    }
                    ImGui.Unindent();
                    
                }
                BorderGroup.EndBoarder();
            }
        }
    }
}