using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSX_WarEasyMap
{
    class GlobalData
    {

    }
    public struct FSXatWarCampaign
    {
        public Packs Packs { get; set; }
        public Theater Theater { get; set; }
        public campaign campaign { get; set; }
    }
    public struct Packs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MinVersion { get; set; }
    }
    public struct Theater
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public struct Mission
    {
        public List<Packs> Packs { get; set; }
        public Theater Theater { get; set; }
    }
    public struct campaign
    {
        public platforms platforms { get; set; }
        public belligerents belligerents { get; set; }
        public weaponImpacts weaponImpacts { get; set; }
    }
    public struct platforms
    {
        public List<Platform> platformsList { get; set; }
    }
    public struct Platform
    {
        public string id { get; set; }
        public string name { get; set; }
        public string typeId { get; set; }
        public bool hasRunway { get; set; }
        public string icao { get; set; }
        public bool isSamSiteSA2 { get; set; }
        public string belligerentId { get; set; }
        public position position { get; set; }
    }
    public struct position
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double heading { get; set; }
    }
    public struct staticUnits
    {
        public List<StaticUnit> StaticUnits { get; set; }
    }
    public struct StaticUnit
    {
        public string id { get; set; }
        public string name { get; set; }
        public string equipmentId { get; set; }
        public position position { get; set; }
        public int weight { get; set; }
        public int damages { get; set; }
    }
    public struct belligerents
    {
        List<Belligerent> belligerentsList { get; set; }
    }
    public struct Belligerent
    {
        public string id { get; set; }
        public string name { get; set; }
        public int team { get; set; }

    }
    public struct textures
    {
        List<BelligerentTexture> texturesList { get; set; }
    }
    public struct BelligerentTexture
    {
        public string name { get; set; }
    }
    public struct weaponImpacts
    {
        List<WeaponImpact> weaponImpactsList { get; set; }
    }
    public struct WeaponImpact
    {
        public string weaponId { get; set; }
        public string weaponName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
