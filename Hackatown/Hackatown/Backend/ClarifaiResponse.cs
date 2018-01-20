using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hackatown.Backend
{
    class ClarifaiResponse
    {
        public Status Status { get; set; }
        public List<Output> Outputs { get; set; }

    }

    class Status
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }

    class Output
    {
        public string Id { get; set; }
        public Status Status { get; set; }
        public string CreatedAt { get; set; }
        public Model Model { get; set; }
        public Input Input { get; set; }
        public Data1 Data { get; set; }

    }

    class Model
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string AppId { get; set; }
        public OutputInfo OutputInfo { get; set; }
        public ModelVersion ModelVersion { get; set; }

    }
    class OutputInfo
    {
        public OutputConfig OutputConfig { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string TypeExt { get; set; }
    }
    class OutputConfig
    {
        public bool ConceptsMutuallyExclusive { get; set; }
        public bool ClosedEnvironment { get; set; }
    }
    class ModelVersion
    {
        public string Id { get; set; }
        public string CreatedAt { get; set; }
        public Status Status { get; set; }
        public int TotalInputCount { get; set; }
    }
    class Input
    {
        public string Id { get; set; }
        public Data2 Data { get; set; }

    }
    class Data1
    {
        public List<Concept> Concepts { get; set; }
    }
    class Data2
    {
        public Image Image { get; set; }
    }
    class Image
    {
        public string Url { get; set; }
        public bool Base64 { get; set; }
    }
    class Concept
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string  App_Id { get; set; }
    }
}