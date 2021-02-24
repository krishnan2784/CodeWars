using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars.Morse_Code_Decoder
{

    public class KMeans
    {

        private bool _done = false;

        private readonly Cluster[] _clusters = new Cluster[3];

        //  Each cluster conforms appropriate time unit
        private string[] _bitCollection;

        //  Bits parsed in collection of 0s and 1s
        private Dictionary<int, int> _dist = new Dictionary<int, int>();

        //  Length of bit line -> number of appearances
        private List<int> _keys;

        //  Lengths of 0s and 1s lines, which appears in the bit code
        public KMeans(string bitStream)
        {

            if (bitStream.Length == 0)
            {
                _bitCollection = new string[1];
                _bitCollection[0] = "";
            }
            else
            {
                var ones = Regex.Split(bitStream, @"0+");
                var zeros = Regex.Split(bitStream, @"1+");
                _bitCollection = new string[ones.Length + (zeros.Length - 1)];
                
                for (var i = 0; i < ones.Length - 1; i++)
                {
                    _bitCollection[2 * i] = ones[i];
                    _bitCollection[2 * i + 1] = zeros[i + 1];
                }

                _bitCollection[^1] = ones[^1];
            }

            foreach (var s in _bitCollection)
            {
                if (string.IsNullOrEmpty(s))
                    continue;
                if (!_dist.ContainsKey(s.Length))
                {
                    _dist.Add(s.Length, 1);
                }
                else
                    _dist[s.Length] = _dist[s.Length] + 1;


            }

            _keys = new List<int>(_dist.Keys);
            switch (_keys.Count)
            {
                case 1:
                    InitClusters(_keys[0]);
                    _done = true;
                    break;
                case 2:
                    _keys.Sort();
                    InitClusters(_keys[0]);
                    break;
                default:
                    _keys.Sort();
                    InitClusters();
                    break;
            }

        }

        private void InitClusters()
        {
            
            _clusters[0] = new Cluster(_keys[0]);
            _clusters[2] = new Cluster(_keys[^1]);
            _clusters[1] = new Cluster((_clusters[0]._location + _clusters[2]._location) / 2 + 1);
        }

        private void InitClusters(int p)
        {
            _clusters[0] = new Cluster(p);
            _clusters[0].AddPoint(p);
            _clusters[1] = new Cluster(p * 3);
            _clusters[2] = new Cluster(p * 7);
        }

        private void MakeAssignment()
        {
            Clear();
            foreach (var i in _keys)
            {
                var bestCluster = new Cluster();
                var closest = float.MaxValue;
                foreach (var c in _clusters)
                {
                    var d = c.GetDistance(i);
                    if (!(d < closest)) 
                        continue;
                    closest = d;
                    bestCluster = c;

                }

                for (var j = 0; j < _dist[i]; j++)
                {
                    bestCluster.AddPoint(i);
                }

            }

        }

        public void Run()
        {
            if (_done) return;
            MakeAssignment();
            while (!_done)
            {
                Update();
                MakeAssignment();
                if (!WasChanged())
                    _done = true;
                

            }

        }

        private void Clear()
        {
            foreach (var c in _clusters)
            {
                c.ClearPoints();
            }

        }

        private void Update()
        {
            foreach (var c in _clusters)
            {
                c.Update();
            }

        }

        private bool WasChanged()
        {
            return _clusters.Any(c => c.WasChanged());
        }

        public int FindClusterByPoint(int p)
        {
            var sorted = _clusters.ToList();
            sorted.Sort();
            for (var i = 0; i < 3; i++)
            {
                if (sorted[i].CurrentPoints.Contains(p))
                {
                    return i;
                }

            }

            return -1;
        }

        private class Cluster:IComparable
        {

            public float _location;

            private float _centroid;

            public List<int> CurrentPoints = new List<int>();

            public List<int> PreviousPoints = new List<int>();

            public Cluster(float loc)
            {
                _location = loc;
            }

            public Cluster()
            {
                _location = -1;
            }

            public void AddPoint(int i)
            {
                CurrentPoints.Add(i);
            }

            public bool WasChanged()
            {
                if (PreviousPoints.Count != CurrentPoints.Count)
                {
                    return true;
                }
                else
                {
                    return !CurrentPoints.Equals(PreviousPoints);
                }

            }

            public void ClearPoints()
            {
                PreviousPoints = CurrentPoints;
                CurrentPoints.Clear();
            }

            public void Update()
            {
                var sum = CurrentPoints.Aggregate<int, float>(0, (current, p) => current + p);

                _centroid = sum / CurrentPoints.Count;
                SetLocation(_centroid);
            }

            public float GetLocation()
            {
                return _location;
            }

            public float GetDistance(int point)
            {
                return Math.Abs(_location - point);
            }

            public void SetLocation(float loc)
            {
                _location = loc;
            }

            public int CompareTo(Cluster t)
            {
                if (GetLocation() > t.GetLocation())
                {
                    return 1;
                }
                else if (GetLocation() < t.GetLocation())
                {
                    return -1;
                }
                else
                {
                    return 0;
                }

            }

            public int CompareTo(object obj)
            {
                if (obj == null) throw new ArgumentNullException(nameof(obj));
                return CompareTo((Cluster) obj);
            }
        }
    }
}